ftp -v ftp://ericminio:Yose12345@www.ericminio-yose.somee.com <<-ENDTAG
binary
prompt
cd www.ericminio-yose.somee.com

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