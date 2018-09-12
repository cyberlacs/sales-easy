/*
 * Parte 07
 * Código copiado pois video aula parte 07 Juan Zuluaga copia para evitar fadiga kkkkkkibosta
 * Este código serve para dar refresh informações vindas do servidor
 * Sales.ViewModels.ProductViewModel herda desta classe
 * https://github.com/Zulu55/Sales/blob/Group0/Sales/Sales/ViewModels/BaseViewModel.cs
 */
namespace Sales.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            this.OnPropertyChanged(propertyName);
        }
    }
}
