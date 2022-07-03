<h1>Redis öğrenirken almış olduğum notları ve kod örneklerini içerir.</h1>

<h2>Redis Kurulumu</h2>
<p>      
   <i>
      - "docker pull redis" komutu ile dockerhub üzerinden Redis image'ini bilgisayarımıza çekiyoruz. 
      - Daha sonra "docker run -p 6379:6379 --name test-redis -d redis" komutu ile çektiğimiz image'i dışarıdan erişebilmek için mapliyoruz ve container ismi vererek ayağa kaldırıyoruz.
      - Containerın ayağa kalktığından emin olduktan sonra, "docker exec -it {containerId} sh" komutu ile Redis container'ımızın içerisine giriyoruz. 
      - "redis-cli" komutuyla artık Redis servera client terminal üzerinden erişim sağlamış oluyoruz. Test amaçlı "set key value" şeklinde bir değer giriyoruz ve çıktı olarak "OK" geri dönüşünü aldığımızdan emin olduktan sonra, ilk verimizi kayıt etmiş bulunuyoruz.
   </i>
   
   <b>Terminalden Redis servera kayıt ekleme ve görüntüleme işlemleri.</b>
   <i>
      Redis containerının çalışır halde olduğundan emin olduktan sonra terminal üzerinden, "docker exec -it {containerId} sh" komutu ile Redis servera bağlanıyoruz. "redis-cli" ile komut satırına geçiş yapıyoruz.
      
      "set key value" ile yeni bir kayıt eklenir.
      "get key value" ile eklenen kayıt görüntülenir.
      "getrange key startIndex endIndex" ile kaydın belirlenen indexleri görüntülenir.
      "incr key" komutu ile integer bir value 1 arttırılır.
      "incrby key incrementValue" ile belirlenen değer kadar arttırılır.
      "decr key" ile 1 eksiltilir.
      "decrby decrementValue" komutu ile belirlenen değer kadar değer eksiltilir.
      "append key value" ile mevcut value değerine girilen değer eklenir.
      "lpush key value" ile listeye soldan değer girilir.
      "lpop key" ile listenin solundan değer silinir.
      "rpush key value" ile sağdan eleman eklenir.
      "rpop key" ile sağdan değer silinir.
      "lrange key startIndex endIndex" ile listedeki elemanlar görüntülenir.
      "sadd key value" ile [blue, red] şeklinde benzersiz kayıt eklenir.
      "smembers key" komutu ile veriler görüntülenir.
      "srem key value" ile verilen değer array içerisinden silinir.
      "zadd key score value" ile sıralı listeye eleman eklenir.
      "zrange key 0 -1" listedeki 0 ile tüm elemanları gösterir.
      "zrem key value" ile listeden eleman silinir.
      "hmset key field value" ile array üzerinde key value şeklinde veriler eklenir.
      "hget key field" ile objenin içerisindeki veriyi okuruz.
      "hdel key field" ile ilgili veri silinir.
      "hgetall key" ile tüm kayıtlar listelenir.
      
      Redis cli girilirken "redis-cli --raw" komutu ile ayağa kaldırılırsa, Türkçe karakterlerin okunması sağlanır.
   </i>
</p>

<h2>IDistributedCacheRedis Project</h2>
   <i>
      IDistributed cache redis projesi, ProductsController içerisinde, key value şeklinde değerlerin cache üzerine kayıt edilmesi.
      Bir class objesinin, json formatla birlikte cache üzerine yazılması ve aynı instance byteArray olarak cache kayıt edilmesi gerçekleştirildi.
   </i>
