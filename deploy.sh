ftp -v ftp://ericminio-001:Yose12345@ftp.mywindowshosting.com <<-ENDTAG
binary
prompt
cd site1

mdelete views/*
rmdir views
mdelete bin/*
rmdir bin
mdelete *

lcd Yose

put Web.config

mkdir bin
lcd bin
cd bin
mput *.dll
lcd ..
cd ..

mkdir views
lcd views
cd views
mput *.html
lcd ..
cd ..

ls
ls views
ls bin

ENDTAG