using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoColor.MainViewModel
{
    


    
        public abstract class BaseViewModel : INotifyPropertyChanged
        {
            #region Свойства

            #endregion

            #region Методы

            /// <summary>
            /// Обновить свойство с вызовом события изменения только если новое значение отлично от предыдущего.
            /// </summary>
            /// <typeparam name="T">Тип свойства.</typeparam>
            /// <param name="field">Свойство.</param>
            /// <param name="value">Новое значение</param>
            /// <param name="propertyName">Наименование свойства.</param>
            /// <returns>Флаг установки нового значения.</returns>
            protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            {
                // проверяем на совпадение
                if (Equals(field, value))
                    return false;

                // если различаются, выставляем и сообщаем
                field = value;
                RaisePropertyChanged(propertyName);

                return true;
            }

            #endregion

            #region События

            /// <summary>
            /// Событие об изменении свойства.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }
}


