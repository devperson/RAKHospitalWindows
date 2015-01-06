using GalaSoft.MvvmLight.Command;
using RAKHospitalAdmin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;

namespace RAKHospitalAdmin.ViewModels
{
    public class DischargeViewModel : ObservableObject
    {        
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    this.RaisePropertyChanged(p => p.Name);
                }
            }
        }
        private string _docName;
        public string DocName
        {
            get { return _docName; }
            set
            {
                if (value != _docName)
                {
                    _docName = value;
                    this.RaisePropertyChanged(p => p.DocName);
                }
            }
        }
        private string _dateDis;
        public string DateDischargedString
        {
            get { return _dateDis; }
            set
            {
                if (value != _dateDis)
                {
                    _dateDis = value;
                    this.RaisePropertyChanged(p => p.DateDischargedString);
                }
            }
        }
        private string _dateAdmitted;
        public string DateAdmittedString
        {
            get { return _dateAdmitted; }
            set
            {
                if (value != _dateAdmitted)
                {
                    _dateAdmitted = value;
                    this.RaisePropertyChanged(p => p.DateAdmittedString);
                }
            }
        }
        private double _total;
        public double TotalAmount
        {
            get { return _total; }
            set
            {
                if (value != _total)
                {
                    _total = value;
                    this.RaisePropertyChanged(p => p.TotalAmount);
                }
            }
        }
        
        
        private DateTime? _dischargeDate = DateTime.Now;
        public DateTime? SelectedDischargeDate
        {
            get { return _dischargeDate; }
            set
            {
                if (value != _dischargeDate)
                {
                    _dischargeDate = value;
                    this.RaisePropertyChanged(p => p.SelectedDischargeDate);
                }
            }
        }

        private ObservableCollection<Patient> _patients;
        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                if (value != _patients)
                {
                    _patients = value;
                    this.RaisePropertyChanged(p => p.Patients);
                }
            }
        }

        private Patient _selectedPat;
        public Patient SelectedPatient
        {
            get { return _selectedPat; }
            set
            {
                if (value != _selectedPat)
                {
                    _selectedPat = value;
                    this.RaisePropertyChanged(p => p.SelectedPatient);                    
                }
            }
        }

       
        #endregion

        #region DischargeCommand
        private RelayCommand _dischargeCommand;
        public RelayCommand DischargeCommand
        {
            get { return _dischargeCommand ?? (_dischargeCommand = new RelayCommand(OnDischargeCommand)); }
        }

        private void OnDischargeCommand()
        {
            if (this.SelectedPatient == null)
            {
                MessageBox.Show("Please select Patient", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            this.Name = this.SelectedPatient.Name;
            this.DocName = this.SelectedPatient.Doctor.Name;
            this.DateAdmittedString = this.SelectedPatient.DateAdmitted.ToShortDateString();
            this.DateDischargedString = this.SelectedDischargeDate.GetValueOrDefault().ToShortDateString();

            var days = Math.Ceiling((this.SelectedDischargeDate - this.SelectedPatient.DateAdmitted).GetValueOrDefault().TotalDays);
            this.TotalAmount = this.SelectedPatient.RoomCategory.Cost * days;

            this.SelectedPatient = null;
            this.SelectedDischargeDate = null;
        }
        #endregion
        
        public void LoadData()
        {
            this.IsLoading = true;
            this.AsyncMethodExecuter((e) =>
            {                
                var patRep = new PatientRepository();
                e.Result = patRep.GetIgerly().ToList();
            },
            (e) =>
            {
                this.IsLoading = false;
                var patients = e.Result as IEnumerable<Patient>;                
                this.Patients = new ObservableCollection<Patient>(patients);                
            });                        
        }
       
    }
}
