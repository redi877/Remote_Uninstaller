using System.Management.Automation;

namespace RemoverAPP;

public class AddHost {

public static Form AddWindow;
public static Button SavePC;
public static TextBox InPutPC2;


        

public static void Add_Pc (object sender, EventArgs e) {

        AddWindow = new Form ();
        
        
        AddWindow.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       // AddWindow.ClientSize = new System.Drawing.Size(800, 450);
        AddWindow.Text = "Input PC Window";
        AddWindow.Size = new System.Drawing.Size(250, 110);
        AddWindow.Location = Form1.Soft.Location;
        AddWindow.Show();

        InPutPC2 = new TextBox();
        InPutPC2.Location = new System.Drawing.Point(20,20);
        InPutPC2.MaxLength = 70;
        InPutPC2.Size = new System.Drawing.Size(110, 1);
        InPutPC2.Text = "Host Name";
        
        AddWindow.Controls.Add(InPutPC2);

        SavePC = new Button();
        SavePC.Location = new System.Drawing.Point(140,20);
        SavePC.Text = "Load";

        LoadSoft LS = new LoadSoft();
        
        SavePC.Click += new EventHandler(LS.LoadList);
        AddWindow.Controls.Add(SavePC);
        



}


}