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

            //�������� �� ���������� ��� �����
            if (int.TryParse(TBAge.Text, out int age) && int.TryParse(TBId.Text, out int id))
            {
                Patient patient = new Patient(firstName, lastName, age, id);
                hospitalQueue.AddPatient(patient);
                UpdateQueueListBox(); //��������� ������ �������
            }
            else
            {
                MessageBox.Show("������������ ������ ��������� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ������ ��������� �����
            TBFirstName.Clear();
            TBLastName.Clear();
            TBAge.Clear();
            TBId.Clear();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            int.TryParse(TBId.Text, out int id);
            hospitalQueue.RemovePatientById(id); // ������� �������� �� ������� �� ID
            UpdateQueueListBox();
            TBId.Clear();
        }

        private void UpdateQueueListBox()
        {
            listBoxQuque.Items.Clear();
            string queueInfo = hospitalQueue.DisplayQueue();
            // ���������� ������ queueInfo �� ������ �������� ��� ��������� � ����������� ������� � ��������
            string[] patientInfoArray = queueInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            // ��������� ���������� � ��������� � ������ �������
            foreach (string patientInfo in patientInfoArray)
            {
                listBoxQuque.Items.Add(patientInfo);
            }
        }

    }
}