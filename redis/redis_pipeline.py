import redis

r = redis.Redis(host='localhost', port=6379, db=0)

pipe = r.pipeline()

pipe.set("nombre", "Vicente")
pipe.set("apellido", "Cubells")
pipe.expire("apellido", 60)
pipe.keys("*")

responses = pipe.execute()

for response in responses:
    print(response)