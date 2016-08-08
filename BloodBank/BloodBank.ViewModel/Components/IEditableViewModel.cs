using System;
using AutoMapper;

namespace BloodBank.ViewModel {
    public interface IEditableViewModel<TModel> : IViewModel<TModel> where TModel : class {
        bool CanCancel { get; }
        bool CanSave { get; }
        bool IsChanged { get; set; }
        Action<IMappingOperationOptions> MappingOpts { get; }
        void Cancel();
        void ForceValidation();
        void Save();
    }
}