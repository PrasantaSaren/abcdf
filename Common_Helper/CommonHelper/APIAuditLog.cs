using Common_Helper.AppCode;
using Common_Helper.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common_Helper.CommonHelper.AuditLog;

namespace Common_Helper.CommonHelper
{
    public class AuditLog
    {
        public static IConfiguration? Configuration { get; set; }
        public static string? logconnstring { get; set; }
        public enum BeLogLevel { Information = 0, Warning = 1, Error = 2, Critical = 3 };

        public enum BeLogType { General = 0, SQL = 1, Others = 2, Success = 3 };
        public static bool doAuditLogAPI(string json)
        {
            AuditLogMember ?auditLogMember = new AuditLogMember();
            auditLogMember = JsonConvert.DeserializeObject<AuditLogMember>(json);
            bool result = false;
            try
            {
                IDbConnection masterconnection = CommonConnectionHelper.GetCommonDbConnection();
                try
                {
                    //var cs = Configuration?[Configuration.GetConnectionString("ProjectConnection")!];
                    masterconnection.ConnectionString = Configuration?["ConnectionStrings:ProjectConnection"];
                }
                catch
                {
                    masterconnection.ConnectionString = logconnstring;
                }
                var bizBOptionsBuilder = new DbContextOptionsBuilder<AppCommonDBContext>();
                bizBOptionsBuilder.UseSqlServer(masterconnection.ConnectionString);
                AppCommonDBContext _dbContext = new AppCommonDBContext(bizBOptionsBuilder.Options);
                short _eventid = 1;
                _eventid = SetDescriptionBasedOnErrorType(auditLogMember, _eventid);
                var _beAuditLog = new BeAuditLog()
                {
                    Form = auditLogMember?.PAGE,
                    ErrorLevel = Convert.ToInt16(auditLogMember?.ERRORLEVEL),
                    EventId = _eventid,
                    UserEmail = auditLogMember?.USEREMAIL != null ? auditLogMember?.USEREMAIL : "",
                    Ip = auditLogMember?.IP,
                    LogTime = System.DateTime.UtcNow,
                    Code = auditLogMember?.CODE,
                    Description = auditLogMember?.DESCRIPTION,
                    Browser = auditLogMember?.BROWSER,
                    TableId = auditLogMember?.TableID,
                };
                _dbContext.BeAuditLogs.Add(_beAuditLog);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private static short SetDescriptionBasedOnErrorType(AuditLogMember? auditLogMember, short _eventid)
        {
            if (auditLogMember?.ERRORTYPE == BeLogType.SQL)
            {
                auditLogMember.DESCRIPTION = "[SQL]" + auditLogMember.METHODNAME + "-" + auditLogMember.DESCRIPTION;
                _eventid = 209;
            }
            else if (auditLogMember?.ERRORTYPE == BeLogType.General)
            {
                auditLogMember.DESCRIPTION = "[General]" + auditLogMember.METHODNAME + "-" + auditLogMember.DESCRIPTION;
                _eventid = 210;
            }
            else if (auditLogMember?.ERRORTYPE == BeLogType.Others)
            {
                auditLogMember.DESCRIPTION = "[Others]" + auditLogMember.METHODNAME + "-" + auditLogMember.DESCRIPTION;
                _eventid = 211;
            }

            return _eventid;
        }

        public static void CallLog(AuditLogHelper auditLogHelper, AuditLog.BeLogLevel _errorlevel, AuditLog.BeLogType _errortype, string METHODNAME, string? TableID, string ExceptionMsg)
        {
            string json = $"{{\"METHODNAME\":\" {METHODNAME} \",\"PAGE\":\" {METHODNAME} \",\"USEREMAIL\":\" {auditLogHelper.ClientEmail} \",\"IP\":\" {auditLogHelper.ClientIpAddress} \",\"CODE\":\"-\",\"BROWSER\":\"Swagger\",\"TableID\":\" {TableID} \",\"ERRORLEVEL\":\" {_errorlevel} \",\"ERRORTYPE\":\" {_errortype} \",\"DESCRIPTION\":\" {ExceptionMsg}\" }}";
            doAuditLogAPI(json);
        }
    }
    public class AuditLogMember
    {

        public IDbConnection? CONNSTRING { get; set; }

        public string? ERRORDESC { get; set; }

        public string? PAGE { get; set; }

        public BeLogLevel ERRORLEVEL { get; set; }

        public string? USEREMAIL { get; set; }

        public string? IP { get; set; }

        public string? CODE { get; set; }

        public string? DESCRIPTION { get; set; }

        public string? BROWSER { get; set; }

        public string? TableID { get; set; }

        public BeLogType ERRORTYPE { get; set; }

        public string? METHODNAME { get; set; }
    }
    public class AuditLogHelper
    {

        [Newtonsoft.Json.JsonIgnore]
        public string? ClientIpAddress { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string? ClientEmail { get; set; }

    }
}
