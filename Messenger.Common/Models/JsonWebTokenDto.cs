namespace Messenger.Common.Dtos
{
    public class JsonWebTokenDto
    {
        public JsonWebTokenDto(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
