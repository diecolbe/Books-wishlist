namespace challenge.emision.presenters.Interfaces
{
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType Content { get; }
    }
}
