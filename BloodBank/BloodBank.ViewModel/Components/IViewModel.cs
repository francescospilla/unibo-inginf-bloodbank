namespace BloodBank.ViewModel.Components
{
    public interface IViewModel<TModel> where TModel : class
    {
        TModel Model { get; set; }
    }
}