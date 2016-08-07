using System;
using AutoMapper;

namespace BloodBank.ViewModel {
    public interface IEditableViewModel<TModel> where TModel : class {
        bool CanCancel { get; }
        bool CanSave { get; }
        bool IsChanged { get; set; }
        bool IsInitialized { get; }
        Action<IMappingOperationOptions> MappingOpts { get; }
        TModel Model { get; set; }

        void Cancel();
        void ForceValidation();
        void Save();
    }
}