// 代码生成时间: 2025-10-13 22:06:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalEquipmentManagement
{
    // Define a class to represent a medical equipment item.
    public class MedicalEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string SerialNumber { get; set; }
    }

    // Define the MedicalEquipmentManager class to manage the medical equipment.
    public class MedicalEquipmentManager
    {
        private List<MedicalEquipment> equipmentList;

        // Constructor to initialize the list of equipment.
        public MedicalEquipmentManager()
        {
            equipmentList = new List<MedicalEquipment>();
        }

        // Method to add a new equipment item to the list.
        public void AddEquipment(MedicalEquipment equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException(nameof(equipment), "Equipment cannot be null.");
            }

            equipmentList.Add(equipment);
            Console.WriteLine("New equipment added: " + equipment.Name);
        }

        // Method to update an existing equipment item.
        public void UpdateEquipment(int id, MedicalEquipment newEquipmentDetails)
        {
            if (newEquipmentDetails == null)
            {
                throw new ArgumentNullException(nameof(newEquipmentDetails), "New equipment details cannot be null.");
            }

            var equipment = equipmentList.FirstOrDefault(e => e.Id == id);
            if (equipment != null)
            {
                equipment.Name = newEquipmentDetails.Name;
                equipment.Type = newEquipmentDetails.Type;
                equipment.Manufacturer = newEquipmentDetails.Manufacturer;
                equipment.ManufactureDate = newEquipmentDetails.ManufactureDate;
                equipment.SerialNumber = newEquipmentDetails.SerialNumber;
                Console.WriteLine("Equipment updated: " + equipment.Name);
            }
            else
            {
                Console.WriteLine("No equipment found with ID: " + id);
            }
        }

        // Method to delete an equipment item by ID.
        public void DeleteEquipment(int id)
        {
            var equipment = equipmentList.FirstOrDefault(e => e.Id == id);
            if (equipment != null)
            {
                equipmentList.Remove(equipment);
                Console.WriteLine("Equipment deleted: " + equipment.Name);
            }
            else
            {
                Console.WriteLine("No equipment found with ID: " + id);
            }
        }

        // Method to retrieve all equipment items.
        public List<MedicalEquipment> GetAllEquipment()
        {
            return equipmentList;
        }

        // Method to retrieve an equipment item by ID.
        public MedicalEquipment GetEquipmentById(int id)
        {
            return equipmentList.FirstOrDefault(e => e.Id == id);
        }
    }
}
