using System.Management.Automation;

namespace RemoverAPP;

public class RemoveSoft {

DialogResult Msg; 
public void RemoveApp (object sender, EventArgs e) {

    

    if (Form1.Soft.CheckedItems.Count == 0) {

        Console.WriteLine(Form1.Soft.CheckedItems.Count);
        Msg = MessageBox.Show("No Software Selected!", "Remote Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;

     }

    foreach (ListViewItem i in Form1.Soft.CheckedItems) { 
    
    
        Console.WriteLine(i.SubItems[0].Text);

        PowerShell ps = PowerShell.Create();

        ps.Commands.AddScript("Get-CimInstance Win32_Product -ComputerName " + AddHost.InPutPC2.Text + " | Where Name -like '*" + i.SubItems[0].Text + "*' | Invoke-CimMethod -Name 'Uninstall'");

        foreach (PSObject result in ps.Invoke())
      {
          Console.WriteLine((result.Members["ReturnValue"].Value));
          
            if (result.Members["ReturnValue"].Value.ToString() == "0") {

                Msg = MessageBox.Show("Removed " + i.SubItems[0].Text + "", "Remote Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1.Soft.Items.Remove(i);

            }
            else {

                Msg = MessageBox.Show("Not Removed! " + i.SubItems[0].Text + "" + "Error: " + result.Members["ReturnValue"].Value.ToString(), "Remote Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
         
          
      }

    }


    

}



}