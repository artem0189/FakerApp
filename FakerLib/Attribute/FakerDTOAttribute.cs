namespace FakerLib.Attribute
{
    public enum DTOState
    {
        Create,
        Ignore
    }
    public class FakerDTOAttribute : System.Attribute
    {
        public DTOState State { get; }

        public FakerDTOAttribute()
        {
            State = DTOState.Create;
        }
    }
}
