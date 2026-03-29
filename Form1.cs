using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagerApp
{
    public class Form1 : Form
    {
        Color primary = ColorTranslator.FromHtml("#A8D5BA");
        Color accent = ColorTranslator.FromHtml("#FFB6B9");
        Color textDark = Color.FromArgb(40, 40, 40);
        Color textSoft = Color.FromArgb(120, 120, 120);

        Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
        Font normalFont = new Font("Segoe UI", 10, FontStyle.Regular);

        DataGridView grid;
        TaskManager manager = new TaskManager();

        public Form1()
        {
            InitUI();
        }

        void InitUI()
        {
            this.Text = "Task Manager";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.White;

            // ===== SIDEBAR =====
            Panel sidebar = new Panel();
            sidebar.Width = 200;
            sidebar.Height = 200;
            sidebar.Dock = DockStyle.Left;
            sidebar.BackColor = ColorTranslator.FromHtml("#A8D5BA");
            this.Controls.Add(sidebar);

            Label appName = new Label();
            appName.Text = "TugasKu";
            appName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            appName.Location = new Point(20, 20);
            sidebar.Controls.Add(appName);

            Button btnAdd = new Button();
            btnAdd.Text = "Tambah Tugas";
            btnAdd.Size = new Size(150, 40);
            btnAdd.Location = new Point(20, 100);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.BackColor = Color.White;
            btnAdd.Click += (s, e) => AddTask();
            sidebar.Controls.Add(btnAdd);

            // ===== TITLE =====
            Label title = new Label();
            title.Width = 800;
            title.Height = 40;
            title.Text = "Dashboard";
            title.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            title.Location = new Point(220, 20);           
            this.Controls.Add(title);

            // ===== DATAGRID =====
            grid = new DataGridView();           
            grid.Location = new Point(240, 100);
            grid.Size = new Size(740, 400);
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            this.Controls.Add(grid);

            grid.Columns.Add("Name", "Tugas");
            grid.Columns.Add("Mata Kuliah", "Mata Kuliah");
            grid.Columns.Add("Deadline", "Deadline");
            grid.Columns.Add("Prioritas", "Prioritas");
            grid.Columns.Add("Status", "Status");

            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
            editBtn.Text = "Edit";
            editBtn.UseColumnTextForButtonValue = true;
            grid.Columns.Add(editBtn);

            DataGridViewButtonColumn delBtn = new DataGridViewButtonColumn();
            delBtn.Text = "Hapus";
            delBtn.UseColumnTextForButtonValue = true;
            grid.Columns.Add(delBtn);

            grid.CellClick += Grid_CellClick;

            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = textDark;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            grid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E8F5E9");
            grid.DefaultCellStyle.SelectionForeColor = textDark;

            grid.RowTemplate.Height = 35;

            grid.CellFormatting += (s, e) =>
            {
                if (grid.Columns[e.ColumnIndex].Name == "Priority")
                {
                    if (e.Value != null)
                    {
                        if (e.Value.ToString() == "High")
                            e.CellStyle.ForeColor = Color.Red;
                        else if (e.Value.ToString() == "Medium")
                            e.CellStyle.ForeColor = Color.Orange;
                        else
                            e.CellStyle.ForeColor = Color.Green;
                    }
                }
            };

            btnAdd.BackColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.Cursor = Cursors.Hand;

            btnAdd.MouseEnter += (s, e) =>
            {
                btnAdd.BackColor = ColorTranslator.FromHtml("#E8F5E9");
            };

            btnAdd.MouseLeave += (s, e) =>
            {
                btnAdd.BackColor = Color.White;
            };
        }

        void AddTask()
        {
            TaskForm form = new TaskForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                manager.Add(form.Task);
                RefreshGrid();
            }
        }

        void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // EDIT
            if (e.ColumnIndex == 5)
            {
                var existing = manager.GetAll()[e.RowIndex];
                TaskForm form = new TaskForm(existing);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    manager.Update(e.RowIndex, form.Task);
                    RefreshGrid();
                }
            }

            // DELETE
            if (e.ColumnIndex == 6)
            {
                manager.Delete(e.RowIndex);
                RefreshGrid();
            }
        }

        void RefreshGrid()
        {
            grid.Rows.Clear();

            foreach (var t in manager.GetAll())
            {
                grid.Rows.Add(
                    t.Name,
                    t.Course,
                    t.Deadline.ToShortDateString(),
                    t.Priority.ToString(),
                    t.Status.ToString()
                );
            }
        }
    }
}