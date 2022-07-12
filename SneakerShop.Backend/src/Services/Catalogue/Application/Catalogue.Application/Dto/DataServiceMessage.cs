namespace Catalogue.Application.Dto
{
    public class DataServiceMessage
    {
        public bool Result { get; set; }
        public string MainMessage { get; set; }
        public object Data { get; set; }

        public DataServiceMessage()
        {
        }

        public DataServiceMessage(bool result, string mainMessage) : this(result, mainMessage, null)
        {
        }
        public DataServiceMessage(bool result, object data) : this(result, null, data)
        {
        }

        public DataServiceMessage(bool result, string mainMessage, object data)
        {
            Result = result;
            MainMessage = mainMessage;
            Data = data;
        }
    }
}
