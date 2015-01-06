using GalaSoft.MvvmLight.Command;
using RAKHospitalAdmin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.ViewModels
{
    public class MainViewModel
    {

        #region Commands

        #region DoctorsEditorCommand
        private RelayCommand _doctorsEditorCommand;
        public RelayCommand DoctorsEditorCommand
        {
            get { return _doctorsEditorCommand ?? (_doctorsEditorCommand = new RelayCommand(OnDoctorsEditorCommand)); }
        }

        private void OnDoctorsEditorCommand()
        {
            DoctorsWindow win = new DoctorsWindow();
            win.DataContext = new DoctorsViewModel();
            win.ShowDialog();
        }
        #endregion

        #region PatientsEditorCommand
        private RelayCommand _patientsEditorCommand;
        public RelayCommand PatientsEditorCommand
        {
            get { return _patientsEditorCommand ?? (_patientsEditorCommand = new RelayCommand(OnPatientsEditorCommand)); }
        }

        private void OnPatientsEditorCommand()
        {
            PatientsWindow win = new PatientsWindow();
            win.DataContext = new PatientViewModel();
            win.Show();
        }
        #endregion

        #region DischargePatientEditorCommand
        private RelayCommand _dischargePatientEditorCommand;
        public RelayCommand DischargePatientEditorCommand
        {
            get { return _dischargePatientEditorCommand ?? (_dischargePatientEditorCommand = new RelayCommand(OnDischargePatientEditorCommand)); }
        }

        private void OnDischargePatientEditorCommand()
        {
            DischargeWindow win = new DischargeWindow();
            win.DataContext = new DischargeViewModel();
            win.Show();
        }
        #endregion
        #endregion
    }
}
