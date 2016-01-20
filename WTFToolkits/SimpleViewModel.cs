using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WTFToolkits.BindableBase;

namespace WTFToolkits
{
    public class SimpleViewModel : ValidatableBase
    {
        public event Action OnSaveRequest = delegate { };        

        private SimpleModel _model;
        public SimpleModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public RelayCommand OkCommand { get; set; }

        public SimpleViewModel()
        {
            this.Model = new SimpleModel(); 
            OkCommand = new RelayCommand(OnSave, CanSave);
        }

        private void Model_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            this.OkCommand.RaiseCanExecuteChanged();
        }

        private void OnSave()
        {
            HasError = MockErrorData();
            if (HasError)
            {
                this.Model.ErrorsChanged -= Model_ErrorsChanged;
                this.Model.ErrorsChanged += Model_ErrorsChanged;
                return;
            }

            OnSaveRequest();
        }

        /// <summary>
        /// how? dammit, how to generic this shit?
        /// </summary>
        /// <returns></returns>
        private bool MockErrorData()
        {
            var res = false;

            if (string.IsNullOrEmpty(this.Model.Name))
            {
                this.Model.Name = string.Empty;
                res = true;
            }

            if (string.IsNullOrEmpty(this.Model.Description))
            {
                this.Model.Description = string.Empty;
                res = true;
            }

            return res;
        }

        private bool CanSave()
        {
            return !this.Model.HasErrors;
        }
    }
}
