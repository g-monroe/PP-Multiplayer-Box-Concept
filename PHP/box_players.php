<?php

require_once('box_dbcon.php');
$ip = ($_SERVER['REMOTE_ADDR']);
$blq = "SELECT Name from boxes WHERE Name = '$ip' AND Status='Online'";
$checkIP = @mysqli_query($dbc, $blq);
if (!$checkIP){
    //Failed to Establish Connection Error
    die("Error:001esc");
}


$checkedIP = mysqli_fetch_array($checkIP);
if ($checkedIP['Name'] != $ip){
     echo('3');
}else{
    
    
     $blq2 = "SELECT * from boxes WHERE Status = 'Online' AND Name NOT LIKE '$ip'";
     $checkIP2 = @mysqli_query($dbc, $blq2); 
     while ($row = @mysqli_fetch_array($checkIP2)) {
     if ( $row['Status'] == 'Online' ){
         if ( $row['Name'] != $ip ) {
             echo '{user}{uid}'.$row['UID'].'{/uid}{x}'.$row['x'].'{/x}{y}'.$row['y'].'{/y}{boxtype}'.$row['boxType'].'{/boxtype}{Comment}'.$row['Comment'].'{/Comment}{CommentT}'.$row['CommentTime'].'{/CommentT}{/user}';
         }
     }
     }
     echo('1');
}
?>