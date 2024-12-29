﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Policy;
using System.Configuration;
using System.Threading;
using Newtonsoft.Json;
using static WindowsFormsApp3.Menu;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using User_Entity;
using static Google.Apis.Requests.BatchRequest;

namespace WindowsFormsApp3
{
    public partial class Menu : Form
    {
        private TcpClient userM;
        private NetworkStream streamM;
        private TcpClient userChat;
        private NetworkStream streamChat;
        private List<string> serverAddresses = new List<string> { "127.0.0.1:8080", "127.0.0.1:8081" };
        private int currentServerIndex = 0;
        private void StartConnection()
        {
            try
            {
                // Lấy thông tin IP và Port từ danh sách server
                string[] addressParts = serverAddresses[currentServerIndex].Split(':');
                string ip = addressParts[0];
                int port = int.Parse(addressParts[1]);

                userChat = new TcpClient(ip, port); // Kết nối đến server
                streamChat = userChat.GetStream();
                Thread listenThread = new Thread(ListenForMessages);  // Lắng nghe tin nhắn từ server
                listenThread.Start();

                // Cập nhật chỉ số server hiện tại để dùng cho lần kết nối tiếp theo
                currentServerIndex = (currentServerIndex + 1) % serverAddresses.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }
        private void ListenForMessages()
        {
            byte[] buffer = new byte[256];
            int bytesRead;

            while ((bytesRead = streamChat.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] parts = message.Split(':');
                string sender = parts[1];
                string receiver = parts[2];
                string content = parts[3];
                Invoke((MethodInvoker)delegate
                {                    
                    if(username == receiver)
                        richTextBox1.Text += $"{parts[1]}: {parts[3]}\n";
                    
                });
            }
        }
        public Menu(TcpClient user, NetworkStream stream)
        {
            InitializeComponent();
            this.userM = user;
            this.streamM = stream;
            this.Size = new Size(590, 350);
            hide_btn.Visible = false;
            label9.Visible = false;
            g_l.Visible = false;
            gender_text.Visible = false;
            usn_l.Visible = false;
            usn_text.Visible = false;
            inter_l.Visible = false;
            interest_text.Visible = false;
            birth_l.Visible = false;
            birthday_text.Visible = false;
            location_text.Visible = false;
            location_l.Visible = false;
        }

        public string username;
        public string userreceive;
        public User_Entity.User_Model user;
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "kggHKAGWQR5afL75qkBb8jxrvkPRe6bfptpe16Ev",
            BasePath = "https://tinder-e074f-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client = new FirebaseClient(config);
        private async void Done_button_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            while (Image_View.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh ");
                return;
            }
            Image_View.Image.Save(ms, ImageFormat.Jpeg);
            byte[] data = ms.GetBuffer();

            string output = Convert.ToBase64String(data);

            if (location_select.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn địa điểm");
                return;
            }
            var updates = new
            {
                Location = location_select.SelectedItem.ToString(),
                Interests = interest_t.Text,
                ImagePath = output
            };

            try
            {
                FirebaseResponse response = await client.UpdateTaskAsync("Users/" + username, updates);
 
                User_Entity.User_Model result = response.ResultAs<User_Entity.User_Model>();
                MessageBox.Show("Đã thêm thành công");
                location_select.SelectedIndex = -1;
                interest_t.Clear();
                var userResponse = await client.GetTaskAsync("Users/" + username);
                var userData = userResponse.ResultAs<User_Entity.User_Model>();
                location_select.SelectedItem = userData.Location.ToString();
                interest_t.Text = userData.Interests;
                byte[] imageBytes = Convert.FromBase64String(userData.ImagePath);
                MemoryStream a = new MemoryStream(imageBytes);
                Image_View.Image = Image.FromStream(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void Select_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);
                Image_View.Image = img.GetThumbnailImage(195, 136, null, new IntPtr());
            }
        }

        string currentmatchlist = "";
        string currentdislikelist = "";
        string[] dislike;
        string[] matches;
        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {   
                username_t.Text = user.UserName;
                fullname_t.Text = user.FullName;
                gender_t.Text = user.Gender == 0 ? "Male" : "Female";
                dateofbirth_t.Text = user.DateOfBirth.ToString("dd/MM/yyyy");
                location_select.SelectedItem = user.Location.ToString();
                interest_t.Text = user.Interests;
                byte[] imageBytes = Convert.FromBase64String(user.ImagePath);
                MemoryStream ms = new MemoryStream(imageBytes);
                Image_View.Image = Image.FromStream(ms);
                StartConnection();
                if (user.MatchList != null)
                {
                    currentmatchlist = user.MatchList;
                    string[] tempmatches = currentmatchlist.Split(',');
                    matches = new string[tempmatches.Length - 1];
                    Array.Copy(tempmatches, matches, tempmatches.Length - 1);
                }

                if (user.DislikeList != null)
                {
                    currentdislikelist = user.DislikeList;
                    string[] tempdislike = currentdislikelist.Split(',');
                    dislike = new string[tempdislike.Length - 1];
                    Array.Copy(tempdislike, dislike, tempdislike.Length - 1);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private List<string> usersList;

        private int currentPos = 0;

        private int startState = 0;

        private int endSig = 0;
        private async void start_Click(object sender, EventArgs e)
        {
            if (startState == 0)
            {
                string message = $"startMatch";
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                streamM.Write(messageBuffer, 0, messageBuffer.Length);

                startState = 1;

                usersList = await ReceiveUsersListAsync(streamM);

                ShowUser(currentPos);
            }
            else
            {
                MessageBox.Show("Already started.");
            }
        }

        public async Task<List<string>> ReceiveUsersListAsync(NetworkStream stream)
        {
            try
            {
                byte[] buffer = new byte[100000]; // Buffer để lưu trữ dữ liệu
                int bytesRead = 0;
                StringBuilder jsonStringBuilder = new StringBuilder();

                // Đọc dữ liệu từ NetworkStream
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                // Chuyển đổi mảng byte thành chuỗi
                string part = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                jsonStringBuilder.Append(part);


                // Chuyển đổi chuỗi JSON thành danh sách đối tượng
                string jsonString = jsonStringBuilder.ToString();
                List<string> usersList = JsonConvert.DeserializeObject<List<string>>(jsonString);

                return usersList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi nhận dữ liệu: {ex.Message}");
                return null;
            }
        }




        private int checkMatch(string[] matches, string username)
        {
            int i = 0;
            if (matches != null)
            {
                foreach (var match in matches)
                {
                    if (match == username)
                    {
                        i = 1;
                        break;
                    }

                }           
            }

            if (i == 0)
            {
                return i;
            }
            else
            {
                return i;
            }
        }

        User_Model userMatch;

        private async void ShowUser(int pos)
        {
            while (usersList.Count > 0 && pos < usersList.Count)
            {
                if (usersList[pos] == username || checkMatch(matches, usersList[pos]) == 1 || checkDis(dislike, usersList[pos]) == 1)
                {
                    pos++;
                    currentPos++;
                }
                else
                {
                    string message = $"checkMatch:{usersList[pos]}";
                    byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                    streamM.Write(messageBuffer, 0, messageBuffer.Length);


                    byte[] buffer = new byte[12200];
                    int bytesRead;
                    bytesRead = await streamM.ReadAsync(buffer, 0, buffer.Length);

                    string yourmatch = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    string[] parts = yourmatch.Split(':');

                    int gender;
                    bool isGenderValid = int.TryParse(parts[5], out gender);


                    userMatch = new User_Model
                    {
                        UserName = parts[0],
                        Password = parts[1],
                        FullName = parts[2],
                        DateOfBirth = DateTime.Parse(parts[3]),
                        Interests = parts[4],
                        Gender = isGenderValid ? gender : -1,
                        Location = parts[6],
                        MatchList = parts[7],
                        ImagePath = parts[8],
                        DislikeList = parts[9],

                    };
                    DateTime dateOfBirth = userMatch.DateOfBirth;
                    DateTime today = DateTime.Today;
                    int age = today.Year - dateOfBirth.Year;

                    if (dateOfBirth > today.AddYears(-age))
                    {
                        age--;
                    }
                    label7.Text = userMatch.FullName + "  " + age.ToString();
                    gender_text.Text = userMatch.Gender == 0 ? "Male" : "Female";
                    birthday_text.Text = userMatch.DateOfBirth.ToString("dd/MM/yyyy");
                    location_text.Text = userMatch.Location.ToString();
                    interest_text.Text = userMatch.Interests;
                    byte[] imageBytes = Convert.FromBase64String(userMatch.ImagePath);
                    MemoryStream ms = new MemoryStream(imageBytes);
                    image_t.Image = Image.FromStream(ms);
                    break;
                }
            }

            if (pos >= usersList.Count)
            {
                MessageBox.Show("No users found.");
                endSig = 1;
            }
        }

        private async void Like_Button_Click(object sender, EventArgs e)
        {
            if (startState == 1 && endSig == 0)
            {


                currentmatchlist += $"{userMatch.UserName},";

                var update = new
                {
                    MatchList = currentmatchlist
                };

                FirebaseResponse response = await client.UpdateTaskAsync("Users/" + username, update);

                if (currentPos < usersList.Count - 1)
                {
                    currentPos++;
                    ShowUser(currentPos);
                }
                else
                {
                    MessageBox.Show("This is the last user.");
                    endSig = 1;
                }
            }
            else if (endSig == 0)
            {
                MessageBox.Show("please start first.");
            }
            else
            {
                MessageBox.Show("This is the last user.");
            }
        }


  
        private async void Dislike_Button_Click(object sender, EventArgs e)
        {
            if (startState == 1 && endSig == 0)
            {
                currentdislikelist += $"{userMatch.UserName},";

                var up = new
                {
                    DislikeList = currentdislikelist
                };

                FirebaseResponse res = await client.UpdateTaskAsync("Users/" + username, up);

                if (currentPos < usersList.Count - 1)
                {
                    currentPos++;
                    ShowUser(currentPos);
                }
                else
                {
                    MessageBox.Show("This is the last user.");
                    endSig = 1;
                }
            }
            else if (endSig == 0)
            {
                MessageBox.Show("please start first.");
            }
            else
            {
                MessageBox.Show("This is the last user.");
            }
        }

        private int checkDis(string[] dis, string username)
        {
            int i = 0;
            if (dis != null)
            {
                foreach (var di in dis)
                {
                    if (di == username)
                    {
                        i = 1;
                        break;
                    }

                }
            }

            if (i == 0)
            {
                return i;
            }
            else
            {
                return i;
            }
        }


        private void show_btn_Click(object sender, EventArgs e)
        {
            this.Size = new Size(590, 290);
            show_btn.Visible = false;
            hide_btn.Visible = true;
            guna2Panel1.Visible = false;
            guna2Panel1.Height = 350;
            label9.Visible = true;
            g_l.Visible = true;
            gender_text.Visible = true;
            usn_l.Visible = true;
            usn_text.Visible = true;
            inter_l.Visible = true;
            interest_text.Visible = true;
            birth_l.Visible = true;
            birthday_text.Visible = true;
            location_text.Visible = true;
            location_l.Visible = true;
            guna2Transition1.ShowSync(guna2Panel1);


        }

        private void hide_btn_Click(object sender, EventArgs e)
        {
            this.Size = new Size(590, 350);
            hide_btn.Visible = false;
            show_btn.Visible = true;
            guna2Panel1.Visible = false;
            label9.Visible = false;
            g_l.Visible = false;
            gender_text.Visible = false;
            usn_l.Visible = false;
            usn_text.Visible = false;
            inter_l.Visible = false;
            interest_text.Visible = false;
            birth_l.Visible = false;
            birthday_text.Visible = false;
            location_text.Visible = false;
            location_l.Visible = false;
            guna2Panel1.Height = 1;
            guna2Transition1.ShowSync(guna2Panel1);
        }

        private async void checkChat(string[] names, string[] chatnames)
        {
            int i = 0;
            foreach(var name in names)
            {
                string message = $"StartChat:{name}";
                byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                streamM.Write(messagebuffer, 0, messagebuffer.Length);

                byte[] buffer = new byte[256];
                int bytesRead;
                bytesRead = await streamM.ReadAsync(buffer, 0, buffer.Length);

                // Chuỗi đầu vào
                string yourmatch = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                // Tìm vị trí của dấu hai chấm và dấu ngoặc kép
                int startIndex = yourmatch.IndexOf(':') + 2; // +2 để bỏ qua dấu cách sau dấu hai chấm
                int endIndex = yourmatch.LastIndexOf('"');

               
                string namesPart = yourmatch.Substring(startIndex, endIndex - startIndex);




                string[]  arr = namesPart.Split(',');

                foreach(var a in arr)
                {
                    if(a == username)
                    {
                        chatnames[i] = a;
                        i++;
                        break;
                    }

                }
            }
        }

        private async void button2_Click(object sender, EventArgs e) // search for matchlist button
        {
            try
            {
                string[] names = currentmatchlist.Split(',');
                string[] chatnames = new string[100];
                int i = 0;
                foreach (var name in names)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        string message = $"StartChat:{name}";
                        byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                        streamM.Write(messagebuffer, 0, messagebuffer.Length);

                        byte[] buffer = new byte[256];
                        int bytesRead;
                        bytesRead = await streamM.ReadAsync(buffer, 0, buffer.Length);
                        // Chuỗi đầu vào
                        string yourmatch = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        // Tìm vị trí của dấu hai chấm và dấu ngoặc kép
                        

                        string[] arr = yourmatch.Split(',');

                        foreach (var a in arr)
                        {
                            if (a == username)
                            {
                                chatnames[i] = name;
                                i++;
                                break;
                            }
                        }
                    }
                }
                comboBox1.Items.Clear(); // Xóa các mục cũ (nếu có)
                var validChatNames = chatnames.Take(i).Where(name => !string.IsNullOrEmpty(name)).ToArray();
                if (validChatNames.Length == 0)
                {
                    MessageBox.Show("You don't have anyone matching you");
                }
                else
                {
                    comboBox1.Items.AddRange(validChatNames); // Thêm các tên vào ComboBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = textBox1.Text;
                if (string.IsNullOrEmpty(userreceive))
                {
                    MessageBox.Show("Please choose someone to chat");
                }    
                else
                {
                    string message = $"Chat:{username}:{userreceive}:{text}";
                    richTextBox1.Text += $"Me: {text}\n";
                    byte[] messagebuffer = Encoding.UTF8.GetBytes(message);
                    streamChat.Write(messagebuffer, 0, messagebuffer.Length);
                    textBox1.Clear();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartConnection();
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userreceive = comboBox1.SelectedItem.ToString();
            var userResponse = await client.GetTaskAsync($"Users/{userreceive}");
            var userData = userResponse.ResultAs<User_Entity.User_Model>();
            var img = userData.ImagePath;
            byte[] imageBytes = Convert.FromBase64String(img);
            MemoryStream ms = new MemoryStream(imageBytes);
            chat_image.Image = Image.FromStream(ms);
            richTextBox1.Clear();
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
