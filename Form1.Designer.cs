namespace RemoverAPP;

public partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    public static ListView Soft;
    private static Button RemoveBtn;
    //private static Button RmBtn;
    //public static TextBox InputPC;
    private static MenuStrip MainMenu;
    
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(450, 550);
        this.Text = "Remote Uninstaller 1.0";
        this.CenterToScreen();
        

        //List of Hosts
        Soft = new ListView();
        Soft.Size = new System.Drawing.Size(430, 450);
        Soft.Location = new System.Drawing.Point(10,60);
        Soft.View = View.Details;
        Soft.LabelEdit = true;
        Soft.AllowColumnReorder = true;
        Soft.CheckBoxes = true;
        Soft.FullRowSelect = true;
        Soft.GridLines = true;
        // Sort the items in the list in ascending order.
        Soft.Sorting = SortOrder.Ascending;
        
        Soft.Columns.Add("Software", -2, HorizontalAlignment.Left);
        Soft.Columns.Add("Version", -2, HorizontalAlignment.Left);
        this.Controls.Add(Soft);

        //Remove Software Button
        RemoveBtn = new Button();
        RemoveBtn.Text = "Remove Selected";
        RemoveBtn.IsAccessible = true;
        RemoveBtn.Size = new System.Drawing.Size(110, 25);
        RemoveBtn.Location = new System.Drawing.Point(10,30);
        
        RemoveSoft RmApp = new RemoveSoft();
        
        RemoveBtn.Click += new EventHandler(RmApp.RemoveApp);
        this.Controls.Add(RemoveBtn);

        //Menu
        MainMenu = new MenuStrip();
        // MenuStrip control with a new window.
        
        ToolStripMenuItem windowMenu = new ToolStripMenuItem("File");
        ToolStripMenuItem windowMenuHelp = new ToolStripMenuItem("Help");
        
        ToolStripMenuItem windowNewMenuAdd = new ToolStripMenuItem("Add", null, new EventHandler(AddHost.Add_Pc));
        ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("Exit", null, new EventHandler(Exit_Click));

        windowMenu.DropDownItems.Add(windowNewMenuAdd);
        windowMenu.DropDownItems.Add(windowNewMenu);
        
        ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowImageMargin = false;
        ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowCheckMargin = true;
        ((ToolStripDropDownMenu)(windowMenuHelp.DropDown)).ShowImageMargin = false;
        ((ToolStripDropDownMenu)(windowMenuHelp.DropDown)).ShowCheckMargin = true;

        MainMenu.MdiWindowListItem = windowMenu;
        MainMenu.MdiWindowListItem = windowMenuHelp;
        
        MainMenu.Items.Add(windowMenu);
        MainMenu.Items.Add(windowMenuHelp);

        MainMenu.Dock = DockStyle.Top;

        this.MainMenuStrip = MainMenu;
        this.Controls.Add(MainMenu);

    }

        void Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
       
    }

 

    
    #endregion
    

}
