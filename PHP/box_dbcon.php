<?php

DEFINE ('DB_USER', 'USER');
DEFINE ('DB_PASSWORD', 'PASS');
DEFINE ('DB_HOST', 'HOST');
DEFINE ('DB_NAME', 'base');

$dbc = @mysqli_connect(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME)
OR die("000dbc");

?>