namespace WindowsFormsApp3
{
    using System;
    using System.Windows.Forms;

    class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            Format = DateTimePickerFormat.Short;

            MinDate = DateTime.Today;
            MaxDate = Value.AddDays(10);

        }

        
        public object EditingControlFormattedValue
        {
            get
            {
                return Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        Value = DateTime.Now;
                    }
                }
            }
        }


        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

 
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

  
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

 
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Пусть DateTimePicker обрабатывает перечисленные ключи.
            switch (key & Keys.KeyCode)
            {
                
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
        
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

   
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // Никакой подготовки не требуется.
        }


        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

    
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

   
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }


        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            //Уведомить представление DataGridView о том, что содержимое ячейки
            // изменились.
            valueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }






    class CalendarEditingControl1 : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl1()
        {
        
            Format = DateTimePickerFormat.Short;
            MinDate = new DateTime(2021,01,01);
            MaxDate =  DateTime.Now;

        }

     
        public object EditingControlFormattedValue
        {
            get
            {
                return Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                 
                        Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                  
                        Value = DateTime.Now;
                    }
                }
            }
        }


        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

   
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
               
                rowIndex = value;
            }
        }

       
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
          
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

  
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // Никакой подготовки не требуется.
        }


        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }


        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

 
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }


        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            //Уведомить представление DataGridView о том, что содержимое ячейки
            // изменились.
            valueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }




}