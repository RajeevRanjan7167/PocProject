using SSISApp.Common.Constants;

namespace SSISApp.Common.Exceptions
{
    public class DataNotFound: Exception
    {
        public string _FieldName { get; }
        public DataNotFound(string fieldName): base(string.Format(ErrorMessages.DataNotFound, fieldName))
        {
                this._FieldName = fieldName;
        }

        public DataNotFound(string fieldName, string messages): base(messages)
        {
                this._FieldName=fieldName;
        }
    }
}
