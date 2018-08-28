<?php

require_once('box_dbcon.php');
$ip = ($_SERVER['REMOTE_ADDR']);
$blq = "SELECT Name from boxes WHERE Name = '$ip'";
$checkIP = @mysqli_query($dbc, $blq);
if (!$checkIP){
    //Failed to Establish Connection Error
    die("Error:001esc");
}


$checkedIP = @mysqli_fetch_array($checkIP);
if ($checkedIP['Name'] != $ip){
     $random_number = intval(rand(1000000,9999999));
     $sql = "INSERT INTO boxes (Name, x, y, Status, UID, boxType, Comment) VALUES ('$ip', '350', '230', 'Online', '$random_number', 'box1','Hello!')";
        if (mysqli_query($dbc, $sql)) {
          echo('1{x}350{/x}{y}230{/y}{boxtype}box1{/boxtype}');
        } else {
            echo("Error:001dbe");
        }
}else{
    $blq2 = "SELECT Name from boxes WHERE Name = '$ip' AND Status='Offline'";
    $checkIP2 = @mysqli_query($dbc, $blq2);
    $checkedIP2 = @mysqli_fetch_array($checkIP2);
    if ($checkedIP2['Name'] != $ip){
        echo('3');
    }else{ 
    $updatekey3 = "UPDATE boxes SET Status='Online' WHERE Name='$ip'";
    $updatedkey3 = @mysqli_query($dbc, $updatekey3);
    $blq4 = "SELECT * from boxes WHERE Status = 'Online' AND Name = '$ip'";
    $checkIP4 = @mysqli_query($dbc, $blq4); 
     while ($row = @mysqli_fetch_array($checkIP4)) {
             echo '2{x}'.$row['x'].'{/x}{y}'.$row['y'].'{/y}{boxtype}'.$row['boxType'].'{/boxtype}';
     }
    }    
}
?>