using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
    public class NuovaIndagineRangeDialogViewModel<T> :Screen where T : IComparable<T>
    {
        public NuovaIndagineRangeDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineRangeDialogViewModel<T>> validator) : base(validator)
        {
        }

        #region Properties

        public new string DisplayName = "Nuova Indagine Range";

        public string Testo { get; set; }
        public Idoneità IdoneitaFallimento { get; set; }
        public T RangeMin { get; set; }
        public T RangeMax { get; set; }

        public IndagineRange<Questionario, T> Model { get; set; }

        #endregion Properties
        
        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();

        #region Save

        public bool CanSave => !HasErrors;

        public void Save()
        {
            if (Validator != null && !Validate()) return;
            Model = CreateModelFromViewModel();
            //TODO: notifica al view parent

        }

        private IndagineRange<Questionario, T> CreateModelFromViewModel()
        {
            return new IndagineRange<Questionario, T>(Testo, IdoneitaFallimento, RangeMin, RangeMax);
        }

        #endregion Save

    }
}
