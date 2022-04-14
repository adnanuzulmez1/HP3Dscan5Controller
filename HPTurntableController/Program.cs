// Decompiled with JetBrains decompiler
// Type: HPTurntableController.Program
// Assembly: HPTurntableController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 71B4AD93-2530-48B6-A110-5AECD4E2B667
// Assembly location: C:\Users\adnan\Desktop\HPTurntableController.exe

using System;
using System.Windows.Forms;

namespace HPTurntableController
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
