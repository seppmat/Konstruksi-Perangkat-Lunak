using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagerApp
{
    public class TaskForm : Form
    {
        public TaskItem Task = new TaskItem();

        TextBox txtName, txtCourse;
        DateTimePicker date;
        ComboBox cbPriority, cbStatus;
        Button btnSave, btnCancel;

        public TaskForm(TaskItem existing = null)
        {
            InitUI();

            if (existing != null)
            {
                txtName.Text = existing.Name;
                txtCourse.Text = existing.Course;
                date.Value = existing.Deadline;
                cbPriority.SelectedItem = existing.Priority;
                cbStatus.SelectedItem = existing.Status;
            }
        }

        void InitUI()
        {
            this.Text = "Tambah";
            this.Size = new Size(360, 460);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AutoScroll = true;

            Color primary = ColorTranslator.FromHtml("#A8D5BA");
            Color textDark = Color.FromArgb(40, 40, 40);
            Color textSoft = Color.FromArgb(120, 120, 120);

            Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font labelFont = new Font("Segoe UI", 9);
            Font inputFont = new Font("Segoe UI", 10);

            int left = 30;
            int width = 260;
            int top = 20;

            int labelGap = 18;   // jarak label ke input
            int sectionGap = 65; // jarak antar field

            // ===== TITLE =====
            Label title = new Label()
            {
                Text = "Tambah / Edit Tugas",
                Font = titleFont,
                ForeColor = textDark,
                Location = new Point(left, top)
            };
            this.Controls.Add(title);

            top += 50;

            // ===== FIELD BUILDER FUNCTION =====
            Func<string, int, TextBox> createField = (text, y) =>
            {
                Label lbl = new Label()
                {
                    Text = text,
                    Location = new Point(left, y),
                    Font = labelFont,
                    ForeColor = Color.FromArgb(120, 120, 120),
                    BackColor = Color.Transparent
                };

                TextBox tb = new TextBox()
                {
                    Location = new Point(left, y + labelGap),
                    Width = width,
                    Font = inputFont,
                    Height = 28
                };

                this.Controls.Add(lbl);
                this.Controls.Add(tb);

                return tb;
            };

            // ===== TASK =====
            txtName = createField("Tugas", top);
            top += sectionGap;

            // ===== COURSE =====
            txtCourse = createField("Mata Kuliah", top);
            top += sectionGap;

            // ===== DEADLINE =====
            Label lblDate = new Label()
            {
                Text = "Deadline",
                Location = new Point(left, top),
                Font = labelFont,
                ForeColor = textSoft,
                BackColor = Color.Transparent,
                
            };
            this.Controls.Add(lblDate);

            date = new DateTimePicker()
            {
                Location = new Point(left, top + labelGap),
                Width = width,
                Font = inputFont,
                Height = 28
            };
            this.Controls.Add(date);

            top += sectionGap;

            // ===== PRIORITY =====
            Label lblPriority = new Label()
            {
                Text = "Prioritas",
                Location = new Point(left, top),
                Font = labelFont,
                ForeColor = textSoft
            };
            this.Controls.Add(lblPriority);

            cbPriority = new ComboBox()
            {
                Location = new Point(left, top + labelGap),
                Width = width,
                Font = inputFont,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbPriority.DataSource = Enum.GetValues(typeof(TaskPriority));
            this.Controls.Add(cbPriority);

            top += sectionGap;

            // ===== STATUS =====
            Label lblStatus = new Label()
            {
                Text = "Status",
                Location = new Point(left, top),
                Font = labelFont,
                ForeColor = textSoft
            };
            this.Controls.Add(lblStatus);

            cbStatus = new ComboBox()
            {
                Location = new Point(left, top + labelGap),
                Width = width,
                Font = inputFont,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbStatus.DataSource = Enum.GetValues(typeof(TaskStatus));
            this.Controls.Add(cbStatus);

            top += 80;

            // ===== BUTTON =====
            Button btnSave = new Button()
            {
                Text = "Simpan",
                Location = new Point(left, top),
                Width = width,
                Height = 42,
                BackColor = primary,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += SaveTask;

            this.Controls.Add(btnSave);

            // Hover effect
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = ColorTranslator.FromHtml("#95CDB0");
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = primary;
        }

        // ===== HELPER =====
        Label CreateLabel(string text, int x, int y, Font font)
        {
            return new Label()
            {
                Text = text,
                Location = new Point(x, y),
                Font = font,
                ForeColor = Color.FromArgb(100, 100, 100)
            };
        }

        TextBox CreateTextBox(int x, int y, int width, Font font)
        {
            TextBox tb = new TextBox()
            {
                Location = new Point(x, y),
                Width = width,
                Font = font
            };
            this.Controls.Add(tb);
            return tb;
        }

        // ===== SAVE =====
        void SaveTask(object sender, EventArgs e)
        {
            Task = new TaskItem
            {
                Name = txtName.Text,
                Course = txtCourse.Text,
                Deadline = date.Value,
                Priority = (TaskPriority)cbPriority.SelectedItem,
                Status = (TaskStatus)cbStatus.SelectedItem
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}