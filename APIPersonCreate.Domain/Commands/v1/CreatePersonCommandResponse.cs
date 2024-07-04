namespace APIPersonCreate.Domain.Commands.v1
{
    public class CreatePersonCommandResponse
    {
        public string Name { get; set; } = string.Empty;
        public Guid Id { get; set; }
    }
}