# -*- mode: ruby -*- 
# vi: set ft=ruby : 
 
# Define the host IP addresses 
hosts = { 
  "ubuntu" => "192.168.36.10", 
  "windows" => "192.168.36.11" 
  #"mac" => "192.168.36.12" 
} 
 
Vagrant.configure("2") do |config| 
  # Common network configuration 
  config.vm.network "public_network", bridge: "default" 
   
    # Ubuntu Machine Configuration 
    config.vm.define "ubuntu" do |ubuntu| 
      ubuntu.vm.box = "bento/ubuntu-22.04" 
      ubuntu.vm.hostname = "ubuntu-vm" 
      # Port forwarding for your specific application 
      ubuntu.vm.network "forwarded_port", guest: 7252, host: 7252 
      # Try both private and public network 
      ubuntu.vm.network "private_network", ip: hosts["ubuntu"] 
      ubuntu.vm.provider "virtualbox" do |v| 
        v.name = "Ubuntu VM" 
        v.memory = "8048" 
        v.cpus = 10 
        # Enable all network adapter types 
        v.customize ["modifyvm", :id, "--nictype1", "82540EM"] 
        v.customize ["modifyvm", :id, "--nictype2", "82540EM"] 
      end 
      ubuntu.vm.synced_folder ".", "/home/vagrant/project" 
      ubuntu.vm.provision "shell", path: "provision-ubuntu.sh" 
    end 
 
 
    config.vm.define "windows" do |windows| 
      windows.vm.box = "StefanScherer/windows_2019" 
      windows.vm.communicator = "winrm" 
       
      windows.vm.provider "virtualbox" do |vb| 
        vb.name = "WindowsVM" 
        vb.gui = true 
        vb.memory = "5096" 
        vb.cpus = 5 
        vb.customize ["modifyvm", :id, "--vram", "128"] 
        vb.customize ["modifyvm", :id, "--natdnshostresolver1", "on"] 
        vb.customize ["modifyvm", :id, "--natdnsproxy1", "on"] 
        vb.customize ["modifyvm", :id, "--clipboard", "bidirectional"] 
      end 
       
      # Налаштування портів для Windows 
      windows.vm.network "forwarded_port", guest: 5050, host: 5052, auto_correct: true 
      windows.vm.network "forwarded_port", guest: 5000, host: 5003, auto_correct: true 
      windows.vm.network "forwarded_port", guest: 3389, host: 33389, auto_correct: true 
      windows.vm.network "forwarded_port", guest: 5985, host: 55985, auto_correct: true 
       
      windows.winrm.username = "vagrant" 
      windows.winrm.password = "vagrant" 
      windows.winrm.transport = :negotiate 
      windows.winrm.basic_auth_only = false 
       
      windows.vm.provision "shell", inline: <<-SHELL 
        # Install Chocolatey 
        Set-ExecutionPolicy Bypass -Scope Process -Force 
        [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072 
        iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) 
 
        # Install .NET SDK 8.0 
        choco install dotnet-8.0-sdk -y 
 
        # Refresh environment variables 
        refreshenv 
 
        dotnet nuget add source http://192.168.56.11:7252/v3/index.json -n Baget 
        dotnet tool install --global lab4 --version 1.0.0 
 
        # Verify installation 
        dotnet --version 
 
        # Navigate to the project directory 
        cd C:\project 
 
        # Run LAB4 
        dotnet run --project lab4 --input lab4\INPUT.TXT --output lab4\OUTPUT.TXT 
 
        Write-Host "Windows environment setup complete and lab4 executed" 
      SHELL 
    end 
 
    # Mac Machine Configuration (commented out) 
    #config.vm.define "mac" do |mac| 
      #mac.vm.box = "ramsey/macos-catalina" 
      #mac.vm.hostname = "mac-vm" 
      #mac.vm.network "private_network", ip: hosts["mac"] 
      #mac.vm.provider "virtualbox" do |v| 
        #v.name = "Mac VM" 
        #v.memory = "4096" 
        #v.cpus = 2 
        #v.customize ["modifyvm", :id, "--nictype1", "82540EM"] 
        #v.customize ["modifyvm", :id, "--nictype2", "82540EM"] 
      #end 
      #mac.vm.synced_folder ".", "/Users/vagrant/project" 
      #mac.vm.provision "shell", path: "provision-mac.sh" 
    #end 
end