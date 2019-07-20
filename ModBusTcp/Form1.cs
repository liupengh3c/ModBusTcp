using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.ModBus;
using HslCommunication;

namespace ModBusTcp
{
    public partial class Form1 : Form
    {
        private ModbusTcpNet busTcpClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_connetc_Click(object sender, EventArgs e)
        {
            string serverIpAddress = this.tb_Server_IpAddress.Text.Trim();
            tb_Server_IpAddress.Enabled = false;
            tb_Server_IpAddress.Enabled = false;
            busTcpClient = new ModbusTcpNet(serverIpAddress, 502, 0x01);
            HslCommunication.OperateResult result = busTcpClient.ConnectServer();
            if (!result.IsSuccess)
            {
                MessageBox.Show("连接服务器失败，请重试");
                return;
            }
            btn_connect.Enabled = false;
            btn_disconnect.Enabled = true;

            // 读线圈部分使能
            tb_coil_address.Enabled = true;
            tb_coil_length.Enabled = true;
            rb_coil_one.Enabled = true;
            rb_coil_two.Enabled = true;
            rb_coil_four.Enabled = true;
            btn_coil_send.Enabled = true;

            // 读寄存器部分使能
            tb_register_address.Enabled = true;
            btn_register_send.Enabled = true;
            rb_register_one.Enabled = true;
            rb_register_two.Enabled = true;
            rb__register_four.Enabled = true;
            tb_register_length.Enabled = true;

            // 读离散使能
            tb_discrete_address.Enabled = true;
            btn_discrete_send.Enabled = true;
            rb_discrete_one.Enabled = true;
            rb_discrete_two.Enabled = true;
            rb_discrete_four.Enabled = true;
            tb_discrete_length.Enabled = true;

            // 写线圈部分使能
            tb_write_coil_address.Enabled = true;
            tb_write_coil_length.Enabled = true;
            rb_write_coil_one.Enabled = true;
            rb_write_coil_two.Enabled = true;
            rb_write_coil_four.Enabled = true;
            btn_write_coil_send.Enabled = true;
            tb_write_coil_data_bit0.Enabled = true;
            //tb_write_coil_data_bit1.Enabled = true;
            //tb_write_coil_data_bit2.Enabled = true;
            //tb_write_coil_data_bit3.Enabled = true;
            //tb_write_coil_data_bit4.Enabled = true;
            //tb_write_coil_data_bit5.Enabled = true;
            //tb_write_coil_data_bit6.Enabled = true;
            //tb_write_coil_data_bit7.Enabled = true;
            //tb_write_coil_data_bit8.Enabled = true;
            //tb_write_coil_data_bit9.Enabled = true;
            //tb_write_coil_data_bit10.Enabled = true;
            //tb_write_coil_data_bit11.Enabled = true;
            //tb_write_coil_data_bit12.Enabled = true;
            //tb_write_coil_data_bit13.Enabled = true;
            //tb_write_coil_data_bit14.Enabled = true;
            //tb_write_coil_data_bit15.Enabled = true;

            // 写寄存器部分使能
            tb_write_register_address.Enabled = true;
            btn_write_register_send.Enabled = true;
            tb_write_register_data.Enabled = true;
            this.cb_write_register_one.Enabled = true;

            // 自动发送部分使能
            this.cb_cron_coil.Enabled = true;
            this.cb_cron_register.Enabled = true;
            this.cb_cron_discrete.Enabled = true;
            this.tb_cron_time.Enabled = true;
            this.btn_cron_start.Enabled = true;
            this.btn_cron_stop.Enabled = true;
        }

        private void Btn_disconnect_Click(object sender, EventArgs e)
        {
            busTcpClient.ConnectClose();
            btn_disconnect.Enabled = false;
            btn_connect.Enabled = true;

            // 读线圈部分禁止
            tb_coil_address.Enabled = false;
            tb_coil_length.Enabled = false;
            rb_coil_one.Enabled = false;
            rb_coil_two.Enabled = false;
            rb_coil_four.Enabled = false;
            btn_coil_send.Enabled = false;

            // 读寄存器部分禁止
            tb_register_address.Enabled = false ;
            tb_register_length.Enabled = false;
            rb_register_one.Enabled = false;
            rb_register_two.Enabled = false;
            rb__register_four.Enabled = false;
            btn_register_send.Enabled = false;

            // 读离散禁止
            tb_discrete_address.Enabled = false;
            btn_discrete_send.Enabled = false;
            rb_discrete_one.Enabled = false;
            rb_discrete_two.Enabled = false;
            rb_discrete_four.Enabled = false;
            tb_discrete_length.Enabled = false;

            // 写线圈部分禁止
            tb_write_coil_address.Enabled = false;
            tb_write_coil_length.Enabled = false;
            rb_write_coil_one.Enabled = false;
            rb_write_coil_two.Enabled = false;
            rb_write_coil_four.Enabled = false;
            btn_write_coil_send.Enabled = false;

            tb_write_coil_data_bit0.Enabled = false;
            tb_write_coil_data_bit1.Enabled = false;
            tb_write_coil_data_bit2.Enabled = false;
            tb_write_coil_data_bit3.Enabled = false;
            tb_write_coil_data_bit4.Enabled = false;
            tb_write_coil_data_bit5.Enabled = false;
            tb_write_coil_data_bit6.Enabled = false;
            tb_write_coil_data_bit7.Enabled = false;
            tb_write_coil_data_bit8.Enabled = false;
            tb_write_coil_data_bit9.Enabled = false;
            tb_write_coil_data_bit10.Enabled = false;
            tb_write_coil_data_bit11.Enabled = false;
            tb_write_coil_data_bit12.Enabled = false;
            tb_write_coil_data_bit13.Enabled = false;
            tb_write_coil_data_bit14.Enabled = false;
            tb_write_coil_data_bit15.Enabled = false;

            // 写寄存器部分禁止
            tb_write_register_address.Enabled = false;
            btn_write_register_send.Enabled = false;
            tb_write_register_data.Enabled = false;
            this.cb_write_register_one.Enabled = false;

            // 自动发送部分禁止
            this.cb_cron_coil.Enabled = false;
            this.cb_cron_register.Enabled = false;
            this.cb_cron_discrete.Enabled = false;
            this.tb_cron_time.Enabled = false;
            this.btn_cron_start.Enabled = false;
            this.btn_cron_stop.Enabled = false;
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            string addr = this.tb_register_address.Text;
            // 读取操作
            //bool coil100 = busTcpClient.ReadCoil("100").Content;   // 读取线圈100的通断
            //short short100 = busTcpClient.ReadInt16(addr).Content; // 读取寄存器100的short值
            //ushort ushort100 = busTcpClient.ReadUInt16(addr).Content; // 读取寄存器100的ushort值
            //int int100 = busTcpClient.ReadInt32("100").Content;      // 读取寄存器100-101的int值
            //uint uint100 = busTcpClient.ReadUInt32(addr).Content;   // 读取寄存器100-101的uint值
            //float float100 = busTcpClient.ReadFloat("100").Content; // 读取寄存器100-101的float值
            //long long100 = busTcpClient.ReadInt64("100").Content;    // 读取寄存器100-103的long值
            //ulong ulong100 = busTcpClient.ReadUInt64("100").Content; // 读取寄存器100-103的ulong值
            //double double100 = busTcpClient.ReadDouble("100").Content; // 读取寄存器100-103的double值
            //string str100 = busTcpClient.ReadString("100", 5).Content;// 读取100到104共10个字符的字符串
            string len = this.tb_register_length.Text;
            ushort length = Convert.ToUInt16(len);
            if (length == 0)
            {
                MessageBox.Show("寄存器长度不能为0，请重新输入！");
                return;
            }
            HslCommunication.OperateResult<byte[]> read = busTcpClient.Read(this.tb_register_address.Text, length);
            uint da = 0;
            string strMsg = "";
            for (int i = 0; i < length; i++)
            {
                da= busTcpClient.ByteTransform.TransUInt16(read.Content, i * 2);
                strMsg += Convert.ToString(da, 2);
            }

            this.rtb_register_recive.Text = strMsg;
        }

        private void Rb_coil_one_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_coil_length.Text = "1";
        }
        private void Rb_coil_two_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_coil_length.Text = "2";
        }
        private void Rb_coil_four_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_coil_length.Text = "4";
        }

        private void Btn_coil_send_Click(object sender, EventArgs e)
        {
            string len = this.tb_coil_length.Text;
            ushort length = Convert.ToUInt16(len);
            if (length == 0)
            {
                MessageBox.Show("线圈长度不能为0，请重新输入！");
                return;
            }
            HslCommunication.OperateResult < bool[]> read = busTcpClient.ReadCoil(this.tb_coil_address.Text, length);
            string strMsg = "";
            for (int i = 0; i < length; i++)
            {
                if (read.Content[i])
                {
                    strMsg += "1";
                }
                else
                {
                    strMsg += "0";
                }
            }
            this.rtb_coil_recive.Text = strMsg;
        }

        private void Rb_register_one_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_register_length.Text = "1";
        }

        private void Rb_register_two_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_register_length.Text = "2";
        }

        private void Rb__register_four_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_register_length.Text = "4";
        }

        private void Rb_discrete_one_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_discrete_length.Text = "1";
        }

        private void Rb_discrete_two_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_discrete_length.Text = "2";
        }

        private void Rb_discrete_four_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_discrete_length.Text = "4";
        }

        private void Btn_discrete_send_Click(object sender, EventArgs e)
        {
            string len = this.tb_discrete_length.Text;
            ushort length = Convert.ToUInt16(len);
            if (length == 0)
            {
                MessageBox.Show("离散量长度不能为0，请重新输入！");
                return;
            }
            HslCommunication.OperateResult<bool[]> read = busTcpClient.ReadDiscrete(this.tb_discrete_address.Text, length);
            string strMsg = "";
            for (int i = 0; i < length; i++)
            {
                if (read.Content[i])
                {
                    strMsg += "1";
                }
                else
                {
                    strMsg += "0";
                }
            }
            this.rtb_discrete_recive.Text = strMsg;
        }

        private void Btn_write_coil_send_Click(object sender, EventArgs e)
        {
            List<bool> sendData = new List<bool>();
            switch (tb_write_coil_length.Text)
            {
                case "1":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    break;
                case "2":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    break;
                case "3":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    break;
                case "4":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    break;
                case "5":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    break;
                case "6":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    break;
                case "7":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    break;
                case "8":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    break;
                case "9":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    break;
                case "10":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    break;
                case "11":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit10.Text == "0" ? false : true);
                    break;
                case "12":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit10.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit11.Text == "0" ? false : true);
                    break;
                case "13":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit10.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit11.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit12.Text == "0" ? false : true);
                    break;
                case "14":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit10.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit11.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit12.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit13.Text == "0" ? false : true);
                    break;
                case "15":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit10.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit11.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit12.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit13.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit14.Text == "0" ? false : true);
                    break;
                case "16":
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit1.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit2.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit3.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit4.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit5.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit6.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit7.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit8.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit9.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit10.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit11.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit12.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit13.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit14.Text == "0" ? false : true);
                    sendData.Add(tb_write_coil_data_bit15.Text == "0" ? false : true);
                    break;
                default:
                    sendData.Add(tb_write_coil_data_bit0.Text == "0" ? false : true);
                    break;
            }
            HslCommunication.OperateResult write = busTcpClient.WriteCoil(this.tb_write_coil_address.Text, sendData.ToArray());
            string strMsg = "[" + DateTime.Now.ToLocalTime().ToString()+ "] ";
            strMsg += write.IsSuccess ? "线圈写入成功。" : "线圈写入失败。错误信息：" + write.Message;
            rtb_write_coil_data.Text += strMsg + "\n";
        }

        private void Rb_write_coil_one_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_write_coil_length.Text = "1";
        }

        private void Rb_write_coil_two_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_write_coil_length.Text = "2";
        }

        private void Rb_write_coil_four_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_write_coil_length.Text = "4";
        }

        private void Btn_write_register_send_Click(object sender, EventArgs e)
        {
            string strData = this.tb_write_register_data.Text.Trim();
            string addr = this.tb_write_register_address.Text.Trim();
            HslCommunication.OperateResult write;
            if (cb_write_register_one.Checked)
            {
                write = busTcpClient.WriteOneRegister(addr, Convert.ToUInt16(strData));
            }
            else
            {
                write = busTcpClient.Write(addr, Convert.ToUInt64(strData));
            }
            if (write.IsSuccess)
            {
                string strMsg = "[" + DateTime.Now.ToLocalTime().ToString() + "] ";
                strMsg += write.IsSuccess ? "线圈写入成功。" : "线圈写入失败。错误信息：" + write.Message;
                rtb_write_register_data.Text += strMsg + "\n";
            }
        }

        private void Tb_write_coil_length_TextChanged(object sender, EventArgs e)
        {
            switch (tb_write_coil_length.Text)
            {
                case "1":
                    tb_write_coil_data_bit0.Enabled = true;
                    //rb_write_coil_one.Checked = true;
                    //rb_write_coil_two.Checked = false;
                    //rb_write_coil_four.Checked = false;

                    tb_write_coil_data_bit1.Enabled = false;
                    tb_write_coil_data_bit2.Enabled = false;
                    tb_write_coil_data_bit3.Enabled = false;
                    tb_write_coil_data_bit4.Enabled = false;
                    tb_write_coil_data_bit5.Enabled = false;
                    tb_write_coil_data_bit6.Enabled = false;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "2":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    //rb_write_coil_one.Checked = false;
                    //rb_write_coil_two.Checked = true;
                    //rb_write_coil_four.Checked = false;

                    tb_write_coil_data_bit2.Enabled = false;
                    tb_write_coil_data_bit3.Enabled = false;
                    tb_write_coil_data_bit4.Enabled = false;
                    tb_write_coil_data_bit5.Enabled = false;
                    tb_write_coil_data_bit6.Enabled = false;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "3":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    

                    tb_write_coil_data_bit3.Enabled = false;
                    tb_write_coil_data_bit4.Enabled = false;
                    tb_write_coil_data_bit5.Enabled = false;
                    tb_write_coil_data_bit6.Enabled = false;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "4":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    //rb_write_coil_one.Checked = false;
                    //rb_write_coil_two.Checked = false;
                    //rb_write_coil_four.Checked = true;

                    tb_write_coil_data_bit4.Enabled = false;
                    tb_write_coil_data_bit5.Enabled = false;
                    tb_write_coil_data_bit6.Enabled = false;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "5":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;

                    tb_write_coil_data_bit5.Enabled = false;
                    tb_write_coil_data_bit6.Enabled = false;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "6":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = false;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "7":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = false;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "8":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = false;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "9":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = false;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "10":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = false;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "11":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = true;
                    tb_write_coil_data_bit11.Enabled = false;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "12":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = true;
                    tb_write_coil_data_bit11.Enabled = true;
                    tb_write_coil_data_bit12.Enabled = false;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "13":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = true;
                    tb_write_coil_data_bit11.Enabled = true;
                    tb_write_coil_data_bit12.Enabled = true;
                    tb_write_coil_data_bit13.Enabled = false;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "14":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = true;
                    tb_write_coil_data_bit11.Enabled = true;
                    tb_write_coil_data_bit12.Enabled = true;
                    tb_write_coil_data_bit13.Enabled = true;
                    tb_write_coil_data_bit14.Enabled = false;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "15":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = true;
                    tb_write_coil_data_bit11.Enabled = true;
                    tb_write_coil_data_bit12.Enabled = true;
                    tb_write_coil_data_bit13.Enabled = true;
                    tb_write_coil_data_bit14.Enabled = true;
                    tb_write_coil_data_bit15.Enabled = false;
                    break;
                case "16":
                    tb_write_coil_data_bit0.Enabled = true;
                    tb_write_coil_data_bit1.Enabled = true;
                    tb_write_coil_data_bit2.Enabled = true;
                    tb_write_coil_data_bit3.Enabled = true;
                    tb_write_coil_data_bit4.Enabled = true;
                    tb_write_coil_data_bit5.Enabled = true;
                    tb_write_coil_data_bit6.Enabled = true;
                    tb_write_coil_data_bit7.Enabled = true;
                    tb_write_coil_data_bit8.Enabled = true;
                    tb_write_coil_data_bit9.Enabled = true;
                    tb_write_coil_data_bit10.Enabled = true;
                    tb_write_coil_data_bit11.Enabled = true;
                    tb_write_coil_data_bit12.Enabled = true;
                    tb_write_coil_data_bit13.Enabled = true;
                    tb_write_coil_data_bit14.Enabled = true;
                    tb_write_coil_data_bit15.Enabled = true;
                    break;
                default:
                    tb_write_coil_data_bit0.Enabled = true;
                    break;
            }
        }

        private void Time_cron_Tick(object sender, EventArgs e)
        {
            if (this.cb_cron_coil.Checked)
            {
                string len = this.tb_coil_length.Text;
                string strMsg = "";
                ushort length = Convert.ToUInt16(len);
                if (length == 0)
                {
                    MessageBox.Show("线圈长度不能为0，请重新输入！");
                    return;
                }
                HslCommunication.OperateResult<bool[]> read = busTcpClient.ReadCoil(this.tb_coil_address.Text, length);
                
                for (int i = 0; i < length; i++)
                {
                    if (read.Content[i])
                    {
                        strMsg += "1";
                    }
                    else
                    {
                        strMsg += "0";
                    }
                }
                this.rtb_cron_data.Text += strMsg + "\n";
            }
            if (this.cb_cron_register.Checked)
            {
                string addr = this.tb_register_address.Text;
                string len = this.tb_register_length.Text;
                ushort length = Convert.ToUInt16(len);
                if (length == 0)
                {
                    MessageBox.Show("寄存器长度不能为0，请重新输入！");
                    return;
                }
                HslCommunication.OperateResult<byte[]> read = busTcpClient.Read(this.tb_register_address.Text, length);
                uint da = 0;
                string strMsg = "";
                for (int i = 0; i < length; i++)
                {
                    da = busTcpClient.ByteTransform.TransUInt16(read.Content, i * 2);
                    strMsg += Convert.ToString(da, 2);
                }
                this.rtb_cron_data.Text += strMsg + "\n";
            }
            if (this.cb_cron_discrete.Checked)
            {
                string len = this.tb_discrete_length.Text;
                ushort length = Convert.ToUInt16(len);
                if (length == 0)
                {
                    MessageBox.Show("离散量长度不能为0，请重新输入！");
                    return;
                }
                HslCommunication.OperateResult<bool[]> read = busTcpClient.ReadDiscrete(this.tb_discrete_address.Text, length);
                string strMsg = "";
                for (int i = 0; i < length; i++)
                {
                    if (read.Content[i])
                    {
                        strMsg += "1";
                    }
                    else
                    {
                        strMsg += "0";
                    }
                }
                this.rtb_cron_data.Text += strMsg + "\n";
            }
        }

        private void Btn_cron_start_Click(object sender, EventArgs e)
        {
            this.time_cron.Interval = Convert.ToInt16(this.tb_cron_time.Text) * 1000;
            this.time_cron.Enabled = true;
            this.btn_cron_start.Enabled = false;
            this.btn_cron_stop.Enabled = true;
        }

        private void Btn_cron_stop_Click(object sender, EventArgs e)
        {
            this.time_cron.Enabled = false;
            this.btn_cron_start.Enabled = true;
            this.btn_cron_stop.Enabled = false;
        }
    }
}
