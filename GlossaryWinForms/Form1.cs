using GlossaryWinForms.Models;
using Newtonsoft.Json;
using System.Text;

namespace GlossaryWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client = new HttpClient();

        private readonly string apiUrl = "https://localhost:7011/api/Terms";

        private DataGridView gridTerms = new DataGridView();

        private TextBox txtSearch = new TextBox();
        private TextBox txtTitle = new TextBox();
        private TextBox txtCategory = new TextBox();
        private TextBox txtDescription = new TextBox();
        private TextBox txtExample = new TextBox();

        private Button btnSearch = new Button();
        private Button btnRefresh = new Button();
        private Button btnAdd = new Button();
        private Button btnUpdate = new Button();
        private Button btnDelete = new Button();
        private Button btnClear = new Button();

        public Form1()
        {
            InitializeComponent();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            CreateDesign();

            _ = LoadTerms();
        }

        private void CreateDesign()
        {
            Text = "Глоссарий офисного работника";
            Width = 1200;
            Height = 720;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 10);

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 75;
            header.BackColor = Color.FromArgb(25, 55, 109);
            Controls.Add(header);

            Label title = new Label();
            title.Text = "Глоссарий офисного работника";
            title.ForeColor = Color.White;
            title.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new Point(25, 15);
            header.Controls.Add(title);

            Label subtitle = new Label();
            subtitle.Text = "Сетевое приложение для хранения и поиска офисных терминов";
            subtitle.ForeColor = Color.FromArgb(210, 220, 240);
            subtitle.Font = new Font("Segoe UI", 9);
            subtitle.AutoSize = true;
            subtitle.Location = new Point(30, 50);
            header.Controls.Add(subtitle);

            Panel searchPanel = new Panel();
            searchPanel.Location = new Point(25, 95);
            searchPanel.Size = new Size(1130, 60);
            searchPanel.BackColor = Color.White;
            Controls.Add(searchPanel);

            Label lblSearch = new Label();
            lblSearch.Text = "Поиск:";
            lblSearch.Location = new Point(15, 20);
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            searchPanel.Controls.Add(lblSearch);

            txtSearch.Location = new Point(75, 16);
            txtSearch.Width = 650;
            txtSearch.Height = 30;
            searchPanel.Controls.Add(txtSearch);

            btnSearch = CreateButton("Найти", 745, 14);
            btnSearch.Click += async (s, e) => await SearchTerms();
            searchPanel.Controls.Add(btnSearch);

            btnRefresh = CreateButton("Обновить", 860, 14);
            btnRefresh.Click += async (s, e) => await LoadTerms();
            searchPanel.Controls.Add(btnRefresh);

            gridTerms.Location = new Point(25, 175);
            gridTerms.Size = new Size(650, 425);
            gridTerms.BackgroundColor = Color.White;
            gridTerms.BorderStyle = BorderStyle.None;
            gridTerms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTerms.MultiSelect = false;
            gridTerms.ReadOnly = true;
            gridTerms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTerms.AllowUserToAddRows = false;
            gridTerms.AllowUserToDeleteRows = false;
            gridTerms.RowHeadersVisible = false;
            gridTerms.Font = new Font("Segoe UI", 10);
            gridTerms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridTerms.CellClick += GridTerms_CellClick;
            Controls.Add(gridTerms);

            Panel card = new Panel();
            card.Location = new Point(700, 175);
            card.Size = new Size(455, 425);
            card.BackColor = Color.White;
            Controls.Add(card);

            Label cardTitle = new Label();
            cardTitle.Text = "Карточка термина";
            cardTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            cardTitle.Location = new Point(20, 15);
            cardTitle.AutoSize = true;
            card.Controls.Add(cardTitle);

            AddLabel(card, "Термин:", 20, 70);
            txtTitle = AddTextBox(card, 20, 95, 410, 30);

            AddLabel(card, "Категория:", 20, 135);
            txtCategory = AddTextBox(card, 20, 160, 410, 30);

            AddLabel(card, "Описание:", 20, 200);
            txtDescription = AddTextBox(card, 20, 225, 410, 75);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            AddLabel(card, "Пример использования:", 20, 315);
            txtExample = AddTextBox(card, 20, 340, 410, 65);
            txtExample.Multiline = true;
            txtExample.ScrollBars = ScrollBars.Vertical;

            btnAdd = CreateButton("Добавить", 25, 625);
            btnAdd.Click += async (s, e) => await AddTerm();
            Controls.Add(btnAdd);

            btnUpdate = CreateButton("Изменить", 145, 625);
            btnUpdate.Click += async (s, e) => await UpdateTerm();
            Controls.Add(btnUpdate);

            btnDelete = CreateButton("Удалить", 265, 625);
            btnDelete.BackColor = Color.FromArgb(190, 60, 60);
            btnDelete.Click += async (s, e) => await DeleteTerm();
            Controls.Add(btnDelete);

            btnClear = CreateButton("Очистить", 385, 625);
            btnClear.Click += (s, e) => ClearFields();
            Controls.Add(btnClear);
        }

        private Button CreateButton(string text, int x, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(110, 34);
            button.BackColor = Color.FromArgb(25, 55, 109);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            return button;
        }

        private void AddLabel(Control parent, string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            parent.Controls.Add(label);
        }

        private TextBox AddTextBox(Control parent, int x, int y, int width, int height)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(width, height);
            textBox.Font = new Font("Segoe UI", 10);

            parent.Controls.Add(textBox);

            return textBox;
        }

        private async Task LoadTerms()
        {
            try
            {
                string json = await client.GetStringAsync(apiUrl);

                List<Term>? terms = JsonConvert.DeserializeObject<List<Term>>(json);

                gridTerms.DataSource = terms;

                ConfigureGridColumns();
            }
            catch
            {
                MessageBox.Show(
                    "Не удалось подключиться к серверу. Проверь, запущен ли проект GlossaryServer.",
                    "Ошибка подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigureGridColumns()
        {
            if (gridTerms.Columns["Id"] != null)
            {
                gridTerms.Columns["Id"].HeaderText = "ID";
                gridTerms.Columns["Id"].Width = 50;
            }

            if (gridTerms.Columns["Title"] != null)
                gridTerms.Columns["Title"].HeaderText = "Термин";

            if (gridTerms.Columns["Category"] != null)
                gridTerms.Columns["Category"].HeaderText = "Категория";

            if (gridTerms.Columns["Description"] != null)
                gridTerms.Columns["Description"].Visible = false;

            if (gridTerms.Columns["Example"] != null)
                gridTerms.Columns["Example"].Visible = false;
        }

        private async Task SearchTerms()
        {
            try
            {
                string query = txtSearch.Text.Trim();

                string url = $"{apiUrl}/search?query={Uri.EscapeDataString(query)}";

                string json = await client.GetStringAsync(url);

                List<Term>? terms = JsonConvert.DeserializeObject<List<Term>>(json);

                gridTerms.DataSource = terms;

                ConfigureGridColumns();
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка поиска. Проверь подключение к серверу.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async Task AddTerm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название термина.");
                return;
            }

            Term term = GetTermFromFields();

            string json = JsonConvert.SerializeObject(term);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Термин успешно добавлен.");
                ClearFields();
                await LoadTerms();
            }
            else
            {
                MessageBox.Show("Ошибка добавления термина.");
            }
        }

        private async Task UpdateTerm()
        {
            if (gridTerms.CurrentRow == null)
            {
                MessageBox.Show("Выберите термин для изменения.");
                return;
            }

            Term selected = (Term)gridTerms.CurrentRow.DataBoundItem;

            Term term = GetTermFromFields();
            term.Id = selected.Id;

            string json = JsonConvert.SerializeObject(term);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{apiUrl}/{term.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Термин успешно изменён.");
                await LoadTerms();
            }
            else
            {
                MessageBox.Show("Ошибка изменения термина.");
            }
        }

        private async Task DeleteTerm()
        {
            if (gridTerms.CurrentRow == null)
            {
                MessageBox.Show("Выберите термин для удаления.");
                return;
            }

            Term selected = (Term)gridTerms.CurrentRow.DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Удалить термин «{selected.Title}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/{selected.Id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Термин удалён.");
                ClearFields();
                await LoadTerms();
            }
            else
            {
                MessageBox.Show("Ошибка удаления термина.");
            }
        }

        private Term GetTermFromFields()
        {
            return new Term
            {
                Title = txtTitle.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Example = txtExample.Text.Trim()
            };
        }

        private void GridTerms_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gridTerms.CurrentRow == null)
                return;

            Term term = (Term)gridTerms.CurrentRow.DataBoundItem;

            txtTitle.Text = term.Title;
            txtCategory.Text = term.Category;
            txtDescription.Text = term.Description;
            txtExample.Text = term.Example;
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtCategory.Clear();
            txtDescription.Clear();
            txtExample.Clear();

            gridTerms.ClearSelection();
        }
    }
}