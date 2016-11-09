<?php
//remember to change the password to whatever you set it in to mysql instance configuration

//first parameter is server name, 2nd username, 'root', 3rd is password 
$rst = @mysql_connect('chargedtest', 'root', '');

echo $_SERVER['SERVER_NAME'];

if(!$rst)
{
    echo( "<p>Unable to connect to Database Manager.</p>");
    die('Could not connect: ' . mysql_error());
    exit();
}
else
{
    echo("<p>Successfully Connected to MySQL Database Manager!</p>");
}

if(!@mysql_select_db("chargeddb"))
{
    echo("<p>Unable to connect to Database</p>");
    exit();
}
else
{
    echo("<p>Successfully Connected to Database 'chargeddb</p>");
}




$close = mysql_close($rst);

?>