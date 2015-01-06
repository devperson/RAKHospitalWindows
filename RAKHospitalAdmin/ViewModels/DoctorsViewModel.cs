using GalaSoft.MvvmLight.Command;
using RAKHospitalAdmin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace RAKHospitalAdmin.ViewModels
{
    public class DoctorsViewModel : ObservableObject
    {
        DataBaseContext context;

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

        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value != _salary)
                {
                    _salary = value;
                    this.RaisePropertyChanged(p => p.Salary);
                }
            }
        }

        private Specialization _selectedSpec;
        public Specialization SelectedSpecialization
        {
            get { return _selectedSpec; }
            set
            {
                if (value != _selectedSpec)
                {
                    _selectedSpec = value;
                    this.RaisePropertyChanged(p => p.SelectedSpecialization);
                }
            }
        }
        

        private ObservableCollection<Specialization> _specializations;
        public ObservableCollection<Specialization> Specializations
        {
            get { return _specializations; }
            set
            {
                if (value != _specializations)
                {
                    _specializations = value;
                    this.RaisePropertyChanged(p => p.Specializations);
                }
            }
        }


        private ObservableCollection<Doctor> _doctors;
        public ObservableCollection<Doctor> Doctors
        {
            get { return _doctors; }
            set
            {
                if (value != _doctors)
                {
                    _doctors = value;
                    this.RaisePropertyChanged(p => p.Doctors);
                }
            }
        }
        #endregion

        #region Commands

        #region AddDoctorCommand
        private RelayCommand _addDoctorCommand;
        public RelayCommand AddDoctorCommand
        {
            get { return _addDoctorCommand ?? (_addDoctorCommand = new RelayCommand(OnAddDoctorCommand)); }
        }

        private void OnAddDoctorCommand()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
               MessageBox.Show("Please enter Doctor name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               return;
            }
            if (this.Salary == 0)
            {
                MessageBox.Show("Please enter Doctor salary", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (this.SelectedSpecialization == null)
            {
                MessageBox.Show("Please select Specialization", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            Doctor doc = new Doctor();
            doc.Name = this.Name;
            doc.Salary = this.Salary;
            doc.Specialization = this.SelectedSpecialization;
            context.Doctors.Add(doc);
            context.SaveChanges();

            this.Doctors.Add(doc);

            this.Name = "";
            this.Salary = 0;
            this.SelectedSpecialization = null;
        }
        #endregion

        #endregion

        public void LoadData()
        {
            this.IsLoading = true;
            this.AsyncMethodExecuter((e) =>
            {
                context = new DataBaseContext();
                DoctorRepository docRep = new DoctorRepository(context);
                SpecializationRepository sRep = new SpecializationRepository(context);

                e.Result = new Tuple<IEnumerable<Doctor>, IEnumerable<Specialization>>(docRep.GetIgerly().ToList(), sRep.GetAll().ToList());
            },
            (e) =>
            {
                this.IsLoading = false;
                var tuple = e.Result as Tuple<IEnumerable<Doctor>, IEnumerable<Specialization>>;
                this.Doctors = new ObservableCollection<Doctor>(tuple.Item1);
                this.Specializations = new ObservableCollection<Specialization>(tuple.Item2);
            });           
        }
    }
}
