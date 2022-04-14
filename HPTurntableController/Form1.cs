

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HPTurntableController
{
  public class Form1 : Form
  {
    private string[] ports = SerialPort.GetPortNames();
    private int scanNumber = 1;
    private int count = 1;
    private Process p = ((IEnumerable<Process>) Process.GetProcessesByName("HP3DScan5")).FirstOrDefault<Process>();
    private IContainer components = (IContainer) null;
    private Label label1;
    private ComboBox comboBox1;
    private Button button2;
    private Label label2;
    private TextBox textBox1;
    private Label label3;
    private CheckBox checkBox1;
    private Button button1;
    private Label label4;
    private Label label5;
    private SerialPort SerialPort1;
    private Timer timer1;
    private Timer timer2;

    [DllImport("User32.dll")]
    private static extern int SetForegroundWindow(IntPtr point);

    public Form1()
    {
      this.InitializeComponent();
      foreach (object port in this.ports)
        this.comboBox1.Items.Add(port);
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.SerialPort1.PortName = this.comboBox1.Text;
      this.SerialPort1.Open();
    }

    private void Button1_Click_1(object sender, EventArgs e)
    {
      this.count = 1;
      string text1 = this.textBox1.Text;
      string text2 = this.textBox1.Text;
      char[] charArray1 = text1.ToCharArray(0, 5);
      char[] charArray2 = text2.ToCharArray(5, 3);
      string s1 = new string(charArray1);
      string s2 = new string(charArray2);
      s2.TrimStart('0');
      s1.TrimStart('0');
      int num1 = int.Parse(s1);
      int num2 = int.Parse(s2);
      int num3 = num2 * 85;
      this.timer1.Interval = num1 + num3;
      this.timer2.Interval = num3;
      this.timer2.Enabled = true;
      Console.WriteLine(num1);
      this.scanNumber = 360 / num2;
      this.label5.Text = this.scanNumber.ToString();
      this.SerialPort1.Write(text1);
    }

    private void Timer1_Tick_1(object sender, EventArgs e)
    {
      --this.scanNumber;
      this.label5.Text = this.scanNumber.ToString();
      if (this.checkBox1.Checked && this.p != null)
      {
        Form1.SetForegroundWindow(this.p.MainWindowHandle);
        SendKeys.SendWait("{F5}");
        --this.count;
      }
      if (this.scanNumber != 0)
        return;
      this.timer1.Enabled = false;
    }

    private void Timer2_Tick_1(object sender, EventArgs e)
    {
      if (this.count == 0)
      {
        this.timer2.Enabled = false;
        --this.scanNumber;
        this.label5.Text = this.scanNumber.ToString();
      }
      else
      {
        if (!this.checkBox1.Checked || this.p == null)
          return;
        Form1.SetForegroundWindow(this.p.MainWindowHandle);
        SendKeys.SendWait("{F5}");
        --this.count;
        this.timer1.Enabled = true;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.button2 = new Button();
      this.label2 = new Label();
      this.textBox1 = new TextBox();
      this.label3 = new Label();
      this.checkBox1 = new CheckBox();
      this.button1 = new Button();
      this.label4 = new Label();
      this.label5 = new Label();
      this.SerialPort1 = new SerialPort(this.components);
      this.timer1 = new Timer(this.components);
      this.timer2 = new Timer(this.components);
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.ForeColor = SystemColors.ButtonFace;
      this.label1.Location = new Point(12, 21);
      this.label1.Name = "label1";
      this.label1.Size = new Size(121, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Select COM Port";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(15, 45);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(92, 21);
      this.comboBox1.TabIndex = 2;
      this.button2.Location = new Point(119, 45);
      this.button2.Name = "button2";
      this.button2.Size = new Size(90, 21);
      this.button2.TabIndex = 3;
      this.button2.Text = "SET PORT";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label2.ForeColor = SystemColors.ButtonFace;
      this.label2.Location = new Point(12, 80);
      this.label2.Name = "label2";
      this.label2.Size = new Size(145, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "Set Time And Angle";
      this.textBox1.Location = new Point(16, 105);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(91, 20);
      this.textBox1.TabIndex = 5;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label3.ForeColor = SystemColors.ButtonFace;
      this.label3.Location = new Point(13, 136);
      this.label3.Name = "label3";
      this.label3.Size = new Size(149, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "Use Auto Next Scan ";
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(165, 138);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(15, 14);
      this.checkBox1.TabIndex = 7;
      this.checkBox1.UseVisualStyleBackColor = true;
      this.button1.Location = new Point(17, 160);
      this.button1.Name = "button1";
      this.button1.Size = new Size(90, 20);
      this.button1.TabIndex = 8;
      this.button1.Text = "START SCAN";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click_1);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label4.ForeColor = SystemColors.ButtonFace;
      this.label4.Location = new Point(13, 192);
      this.label4.Name = "label4";
      this.label4.Size = new Size(129, 16);
      this.label4.TabIndex = 9;
      this.label4.Text = "Remaining Scans";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label5.ForeColor = SystemColors.ButtonFace;
      this.label5.Location = new Point(165, 184);
      this.label5.Name = "label5";
      this.label5.Size = new Size(0, 25);
      this.label5.TabIndex = 10;
      this.timer1.Tick += new EventHandler(this.Timer1_Tick_1);
      this.timer2.Tick += new EventHandler(this.Timer2_Tick_1);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(51, 51, 51);
      this.ClientSize = new Size(221, 227);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form1);
      this.Text = "HP Turntable Controller";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
