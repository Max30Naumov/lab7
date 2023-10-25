namespace lab7
{
    public partial class Form1 : Form
    {
        private HospitalQueue hospitalQueue;

        public Form1()
        {
            InitializeComponent();
            hospitalQueue = new HospitalQueue();
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            UpdateQueueListBox();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string firstName = TBFirstName.Text;
            string lastName = TBLastName.Text;

            //проверка на правильный тип даных
            if (int.TryParse(TBAge.Text, out int age) && int.TryParse(TBId.Text, out int id))
            {
                Patient patient = new Patient(firstName, lastName, age, id);
                hospitalQueue.AddPatient(patient);
                UpdateQueueListBox(); //обновляем список очереди
            }
            else
            {
                MessageBox.Show("Неправильный формат введенных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // очстка текстовых полей
            TBFirstName.Clear();
            TBLastName.Clear();
            TBAge.Clear();
            TBId.Clear();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            int.TryParse(TBId.Text, out int id);
            hospitalQueue.RemovePatientById(id); // удаляем пациента из очереди по ID
            UpdateQueueListBox();
            TBId.Clear();
        }

        private void UpdateQueueListBox()
        {
            listBoxQuque.Items.Clear();
            string queueInfo = hospitalQueue.DisplayQueue();
            // разделение строки queueInfo на массив подстрок для красивого и корректного ввывода в листбокс
            string[] patientInfoArray = queueInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            // добавляем информацию о пациентах в список очереди
            foreach (string patientInfo in patientInfoArray)
            {
                listBoxQuque.Items.Add(patientInfo);
            }
        }

    }
}