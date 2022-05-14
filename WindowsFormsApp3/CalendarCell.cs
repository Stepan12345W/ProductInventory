namespace WindowsFormsApp3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
            : base()
        {
            // Используйте короткий формат даты.
            Style.Format = "yyyy.MM.dd";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Установите значение элемента управления редактированием на текущее значение ячейки.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            // Используйте значение строки по умолчанию, если свойство Value равно нулю.
            if (Value == null)
            {
                ctl.Value = DateTime.UtcNow;
            }
            else
            {
                ctl.Value = DateTime.Now;

            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            var column = (OwningColumn as IColorFormat);
            if (column.ColorFormats != null)
            {
                foreach (var item in (OwningColumn as IColorFormat).ColorFormats)
                {
                    if (item.Predicate((DateTime)Value))
                    {
                        cellStyle.BackColor = item.Color;
                    
                    }
                    if (item.Predicate1((DateTime)Value))
                    {
                       
                        cellStyle.ForeColor = item.Color1;
                        break;
                    }

                }
            }
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        public override Type EditType
        {
            get
            {
                //Возвращает тип элемента управления редактированием, который использует CalendarCell.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                ////Возвращает тип значения, содержащегося в ячейке календаря.

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Используйте текущую дату и время в качестве значения по умолчанию.
                return DateTime.UtcNow;
            }
        }

    }


































    public class CalendarCell1 :  DataGridViewTextBoxCell
    {

        public CalendarCell1()
            : base()
        {
            // Используйте короткий формат даты.
            Style.Format = "yyyy.MM.dd";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Установите значение элемента управления редактированием на текущее значение ячейки.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl1 ctl =
                DataGridView.EditingControl as CalendarEditingControl1;
            // Используйте значение строки по умолчанию, если свойство Value равно нулю.
            if (Value == null)
            {
                ctl.Value = DateTime.UtcNow;
            }
            else
            {
                
                ctl.Value = (DateTime)Value;


            }
        }

     

        public override Type EditType
        {
            get
            {
                //Возвращает тип элемента управления редактированием, который использует CalendarCell.
                return typeof(CalendarEditingControl1);
            }
        }

        public override Type ValueType
        {
            get
            {
                ////Возвращает тип значения, содержащегося в ячейке календаря.

                return typeof(DateTime);
            }
        }

    
    }




}