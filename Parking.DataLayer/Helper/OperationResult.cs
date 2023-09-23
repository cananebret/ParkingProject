using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Helper
{
    public class ValidationResult
    {
        public ValidationResult()
        {

        }

        public ValidationResult(string message, string data = null, int statusCode = 400, string code = null)
        {
            this.Code = code;
            this.Data = data;
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public string Code { get; set; }
        public string Data { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }

    public class OperationResult
    {
        [Key]
        public Guid Key { get; set; }

        public bool HasWarning { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public List<ValidationResult> Errors { get; set; }

        public string DataAsJson { get; set; }

        public string DataType { get; set; }

        public int StatusCode { get; set; }

        public int AffectedRowCount { get; set; }

        public bool SuccessWithoutWarning
        {
            get
            {
                return IsSuccess && !HasWarning;
            }
        }

        public OperationResult(Guid? key, bool hasWarning, bool isSuccess, string message, object data, int statusCode, int affectedRowCount, List<ValidationResult> validationResults = null)
        {
            this.Key = key == null ? Guid.Empty : (Guid)key;
            this.HasWarning = hasWarning;
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.StatusCode = statusCode;
            this.AffectedRowCount = affectedRowCount;
            this.Errors = validationResults;
        }       
    }
}
