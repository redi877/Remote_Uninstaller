using System.Management.Automation;
using System.Net.NetworkInformation;  
using Microsoft.Management.Infrastructure;
using System.Management;
using System.ServiceProcess;


namespace RemoverAPP;

public class LoadSoft {

DialogResult Msg; 
public void LoadList (object sender, EventArgs e) {

AddHost.AddWindow.Hide();

Ping p = new Ping();

Console.WriteLine(AddHost.InPutPC2.Text);

try  
{  
PingReply reply = p.Send(AddHost.InPutPC2.Text, 6000);  
if (reply.Status == IPStatus.Success) {


}  }
catch { 

Msg = MessageBox.Show("Connection Error! Check Hostname.", "Appl Remover", MessageBoxButtons.OK, MessageBoxIcon.Stop);
return; 

}  

ServiceController sc  = new ServiceController("WinRM", AddHost.InPutPC2.Text);
//sc.ServiceName = "WinRM";


if (sc.Status == ServiceControllerStatus.Stopped)
{
   // Start the service if the current status is stopped.

   Console.WriteLine("Starting the WinRM service...");
   try
   {
      // Start the service, and wait until its status is "Running".
      sc.Start();
      sc.WaitForStatus(ServiceControllerStatus.Running);

      // Display the current service status.
      Console.WriteLine("The WinRM service status is now set to {0}.",
                         sc.Status.ToString());
   }
   catch (InvalidOperationException)
   {
      Console.WriteLine("Could not start the Alerter service.");
   }
}




    PowerShell ps = PowerShell.Create();
    
    ps.AddCommand("Get-CimInstance");
    ps.AddParameter("-ClassName", "win32_product");
    ps.AddParameter("-ComputerName", AddHost.InPutPC2.Text);
    
    Console.WriteLine("ok");

    Form1.Soft.Items.Clear();

    foreach (PSObject result in ps.Invoke())
      {
          
          Console.WriteLine(result.Members["Name"].Value);
          
          //Msg = MessageBox.Show(result.Members["Name"].Value.ToString(), "Nazwa Programu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
          
          RemoverAPP.Form1.Soft.Items.Add(result.Members["Name"].Value.ToString()).SubItems.Add(result.Members["Version"].Value.ToString());
          
        
          
      }




}





}