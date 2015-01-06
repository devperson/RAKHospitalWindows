using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RAKHospitalAdmin.ViewModels
{
    /// <summary>
    /// Base class for ViewModels
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        private bool _isloading;
        public bool IsLoading
        {
            get { return _isloading; }
            set
            {
                if (value != _isloading)
                {
                    _isloading = value;
                    this.RaisePropertyChanged(p => p.IsLoading);
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// INotifyPropertyChanged implementation its required to update UI when models changes.
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// With this method we can run code asynchronously
        /// </summary>
        /// <param name="method"></param>
        /// <param name="callback"></param>
        public void AsyncMethodExecuter(Action<DoWorkEventArgs> method, Action<RunWorkerCompletedEventArgs> callback = null)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (s, e) =>
            {
                method(e);
            };
            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                if (callback != null)
                    App.Current.Dispatcher.BeginInvoke(callback, e);
            };
            backgroundWorker.RunWorkerAsync();
        }
    }

    public static class ObservableBaseEx
    {
        /// <summary>
        /// This is extenstion RaisePropertyChanged which allows us to pass properties instead of string property name. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="observableBase"></param>
        /// <param name="expression"></param>
        public static void RaisePropertyChanged<T, TProperty>(this T observableBase, Expression<Func<T, TProperty>> expression) where T : ObservableObject
        {
            observableBase.RaisePropertyChanged(observableBase.GetPropertyName(expression));
        }

        public static string GetPropertyName<T, TProperty>(this T owner, Expression<Func<T, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression == null)
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }

            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }
    }
}
