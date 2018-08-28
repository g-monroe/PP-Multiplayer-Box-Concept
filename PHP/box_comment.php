<?php

require_once('box_dbcon.php');
$ip = ($_SERVER['REMOTE_ADDR']);
$blq = "SELECT Name from boxes WHERE Name = '$ip'";
$comment = $_SERVER['HTTP_COMMENT'];
$checkIP = @mysqli_query($dbc, $blq);
if (!$checkIP){
    //Failed to Establish Connection Error
    die("Error:001esc");
}


$checkedIP = mysqli_fetch_array($checkIP);
if ($checkedIP['Name'] != $ip){
     echo('3');
}else{
    $blq2 = "SELECT Name from boxes WHERE Name = '$ip' AND Status='Online'";
    $checkIP2 = @mysqli_query($dbc, $blq2);
    $checkedIP2 = mysqli_fetch_array($checkIP2);
    if ($checkedIP2['Name'] != $ip){
        echo('2');
    }else{
    $updatekey = "UPDATE boxes SET Comment='$comment' WHERE Name='$ip'";
    $updatedkey = @mysqli_query($dbc, $updatekey);
    $updatekey2 = "UPDATE boxes SET CommentTime=now() WHERE Name='$ip'";
    $updatedkey2 = @mysqli_query($dbc, $updatekey2);
    echo('1');
    }    
}
?>