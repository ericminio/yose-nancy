ftp -v ftp://ericminio:Yose12345@www.ericminio-yose.somee.com <<-ENDTAG
binary
prompt
cd www.ericminio-yose.somee.com
mdelete bin/*
rmdir bin
mdelete *
ls
lcd Yose
put Web.config
mkdir bin
lcd bin
cd bin
mput *.html
mput *.dll
ls
ENDTAG