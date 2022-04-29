using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


namespace TabSwitcher
{
    // возможность скрывать кнопки по желанию пользователя
    // если скрываем одну кнопку одну кнопку, то вторая заполняет весь контрол
    public partial class TabSwitcherClontrol: UserControl1
    {
        #region properties
        private bool bHideBtnPrevious = false; // скрыта ли кнопка Предыдущий
        private bool bHideBtnNext = false; // скрыта ли кнопка Следующий

        public bool IsHideBtnPrevious
        {
            get { return bHideBtnPrevious; }
            set
            {
                bHideBtnPrevious = value;
                SetButtons(); //метод по отрисовке кнопок
            }
        }
        public bool IsHideBtnNext
        {
            get { return bHideBtnNext; }
            set
            {
                bHideBtnNext = value;
                SetButtons();
            }
        }
        #endregion
        //доступна кнопка "Предыдущий"
        private void btnNextTrueBtnFalse()
        {
            btnNext.Visibility = Visibility.Hidden;
            btnPrevios.Visibility = Visibility.Visible;
            btnPrevios.Width = 229;
            btnNext.Width = 0;
            btnPrevios.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        // доступна кнопка "Следующий"
        private void btnPreviosTrueNextFalse()
        {
            btnPrevios.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            btnNext.Width = 229;
            btnPrevios.Width = 0;
            btnNext.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        //обе доступны
        private void btnPreviosFalseBtnNextFalse()
        {
            btnPrevios.Visibility = Visibility.Visible;
            btnNext.Visibility = Visibility.Visible;
            btnNext.Width = 115;
            btnPrevios.Width = 114;
        }
        //обе недоступны
        private void btnPreviousTrueBtnNextTrue()
        {
            btnPrevios.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
        }
        //отрисовка кнопок
        //три варианта: обе доступны, досутпна только одна , обе недоступны
        private void SetButtons()
        {
            if (bHideBtnPrevious && bHideBtnNext) btnPreviousTrueBtnNextTrue();
            else if (!bHideBtnNext && !bHideBtnPrevious) btnPreviosFalseBtnNextFalse();
            else if (bHideBtnNext && !bHideBtnPrevious) btnNextTrueBtnFalse();
            else if (!bHideBtnNext && bHideBtnPrevious) btnPreviosTrueNextFalse();
        }
    }
}
