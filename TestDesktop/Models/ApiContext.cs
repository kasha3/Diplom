using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace TestDesktop.Models
{
    public class ApiContext
    {
        public readonly string baseURL = "http://api.fadeev.website/api/v1"; 

        public List<Employee> GetEmployees()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/employees/desktop");
                request.Method = "GET";
                request.ContentType = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<Employee>>(json);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }

        public Employee PostEmployee(Employee newEmployee)
        {
            try
            {
                string json = JsonConvert.SerializeObject(newEmployee);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/employees");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) 
                    {
                        string jsonResponse = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<Employee>(jsonResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void PutEmployee(Employee redactEmployee)
        {
            string json = JsonConvert.SerializeObject((Employee)redactEmployee);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/employees/{redactEmployee.Id}");
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(bytes, 0, bytes.Length);
            }

            using (HttpWebResponse response  = (HttpWebResponse)request.GetResponse())
            {

            }
        }


        public List<Departament> GetDepartaments()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/department");
                request.Method = "GET";
                request.ContentType = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<Departament>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Position> GetPositions()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/positions");
                request.Method = "GET";
                request.ContentType = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<Position>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Position PostPosition(Position newPosition)
        {
            try
            {
                string json = JsonConvert.SerializeObject(newPosition);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/positions");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string jsonResponse = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<Position>(jsonResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void PutPosition(Position redactPosition)
        {
            try
            {
                string json = JsonConvert.SerializeObject((Position)redactPosition);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/positions/{redactPosition.Id}");
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Organization> GetOrganizations()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/organizations");
                request.Method = "GET";
                request.ContentType = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<Organization>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Absences> GetAbsences()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/absences");
                request.Method = "GET";
                request.ContentType = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<Absences>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Absences PostAbsences(Absences newAbsence)
        {
            try
            {
                string json = JsonConvert.SerializeObject(newAbsence);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/absences");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string jsonResponse = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<Absences>(jsonResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void PutAbsence(Absences redactAbsence)
        {
            try
            {
                string json = JsonConvert.SerializeObject((Absences)redactAbsence);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{baseURL}/absences/{redactAbsence.Id}");
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
