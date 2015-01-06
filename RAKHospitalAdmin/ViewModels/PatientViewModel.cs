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
    /// <summary>
    /// This is class that handles all interaction with Patient Window
    /// </summary>
    public class PatientViewModel : ObservableObject
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

        private DateTime _dateAdmitted = DateTime.Now;
        public DateTime DateAdmitted
        {
            get { return _dateAdmitted; }
            set
            {
                if (value != _dateAdmitted)
                {
                    _dateAdmitted = value;
                    this.RaisePropertyChanged(p => p.DateAdmitted);
                }
            }
        }

        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (value != _selectedRoom)
                {
                    _selectedRoom = value;
                    this.RaisePropertyChanged(p => p.SelectedRoom);
                }
            }
        }
        

        private ObservableCollection<Room> _rooms;
        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                if (value != _rooms)
                {
                    _rooms = value;
                    this.RaisePropertyChanged(p => p.Rooms);
                }
            }
        }

        private Doctor _selectedDoc;
        public Doctor SelectedDoctor
        {
            get { return _selectedDoc; }
            set
            {
                if (value != _selectedDoc)
                {
                    _selectedDoc = value;
                    this.RaisePropertyChanged(p => p.SelectedDoctor);
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
        
        #endregion

        #region Commands

        /// <summary>
        /// This is an add patient command which is executed when user clicks add patient
        /// </summary>
        #region AddPatientCommand
        private RelayCommand _addPatientCommand;
        public RelayCommand AddPatientCommand
        {
            get { return _addPatientCommand ?? (_addPatientCommand = new RelayCommand(OnAddPatientCommand)); }
        }

        private void OnAddPatientCommand()
        {
            // User input validation
            if (string.IsNullOrEmpty(this.Name))
            {
                MessageBox.Show("Please enter Patient name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (this.SelectedRoom == null)
            {
                MessageBox.Show("Please select Room", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (this.SelectedDoctor == null)
            {
                MessageBox.Show("Please select Doctor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            //Adding patient object to database
            Patient pat = new Patient();
            pat.Name = this.Name;
            pat.RoomCategory = this.SelectedRoom;
            pat.Doctor = this.SelectedDoctor;
            pat.DateAdmitted = this.DateAdmitted;
            context.Patients.Add(pat);
            context.SaveChanges();

            //adding saved patient to ListView
            this.Patients.Add(pat);

            this.Name = "";
            this.SelectedRoom = null;
            this.SelectedDoctor = null;
            this.DateAdmitted = DateTime.Now;
        }
        #endregion
        
        #endregion

        /// <summary>
        /// Loads necessary data from Database e.g. existing Doctors, Patients, Rooms
        /// </summary>
        public void LoadData()
        {
            this.IsLoading = true;
            //With AsyncMethodExecuter we can run loading in asyn mode
            this.AsyncMethodExecuter((e) =>
            {
                context = new DataBaseContext();
                DoctorRepository docRep = new DoctorRepository(context);
                PatientRepository patRep = new PatientRepository(context);
                RoomRepository roomRep = new RoomRepository(context);

                e.Result = new Tuple<IEnumerable<Doctor>, IEnumerable<Patient>, IEnumerable<Room>>(docRep.GetIgerly().ToList(), patRep.GetIgerly().ToList(), roomRep.GetAll().ToList());
            },
            (e) =>
            {
                this.IsLoading = false;
                var tuple = e.Result as Tuple<IEnumerable<Doctor>, IEnumerable<Patient>, IEnumerable<Room>>;
                this.Doctors = new ObservableCollection<Doctor>(tuple.Item1);
                this.Patients = new ObservableCollection<Patient>(tuple.Item2);
                this.Rooms = new ObservableCollection<Room>(tuple.Item3);
            });                      
        }
    
    }

}
