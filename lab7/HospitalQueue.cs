using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab7
{
    public class HospitalQueue
    {
        private Queue<Patient> patientsQueue = new Queue<Patient>();

        public HospitalQueue() { }

        //список для отслеживания уникальных ID пациентов
        private List<int> uniqueIds = new List<int>();

        //метод для добавления пациента в очередь
        public void AddPatient(Patient patient)
        {
            //проверка, что ID пациента уникален и больше нуля
            if (IsIdUnique(patient.Id) && patient.Id > 0)
            {
                patientsQueue.Enqueue(patient); //добавляем пациента в очередь
                uniqueIds.Add(patient.Id); //добавляем ID пациента в список уникальных ID
                MessageBox.Show($"{patient.FirstName} {patient.LastName} добавлен в очередь.", "Добавление пациента", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка. Проверьте ID пациента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //мтод для проверки уникальности ID пациента
        private bool IsIdUnique(int id)
        {
            return !uniqueIds.Contains(id);
        }

        //метод для удаления пациента из очереди по ID
        public void RemovePatientById(int id)
        {
            Patient patientToRemove = null;

            foreach (var patient in patientsQueue)
            {
                if (patient.Id == id)
                {
                    patientToRemove = patient; //находим пациента для удаления
                    break;
                }
            }

            if (patientToRemove != null)
            {
                patientsQueue = new Queue<Patient>(patientsQueue.Except(new[] { patientToRemove })); // удаляем пациента из очереди
                uniqueIds.Remove(id); // Remove the ID from the list of unique IDs
                MessageBox.Show($"{patientToRemove.FirstName} {patientToRemove.LastName} удален из очереди.", "Удаление пациента", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пациент с указанным ID не найден в очереди.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //vетод для отображения текущей очереди пациентов
        public string DisplayQueue()
            {
                // создаем объект StringBuilder для построения строки
                StringBuilder result = new StringBuilder();
                result.AppendLine("Текущая очередь пациентов:");
                //прроходим по каждому пациенту в очереди
                foreach (var patient in patientsQueue)
                {
                    result.AppendLine($"Имя: {patient.FirstName} {patient.LastName}, Возраст: {patient.Age}, ID: {patient.Id}");
                }
                // переводимм объект StringBuilder в строку
                return result.ToString();
            }



        } 
    }

