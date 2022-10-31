
*Bug*  
Motorbike / motorcycle mixup  

*Bug*  
if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59)  
  
*Inconsequential but badly expressed*  
if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59)  
  
I changed date format in text to ISO format "2013-02-08T14:35:00"  


Unclear if the API should support multi-hour dates in one call, 
or if its assumed to be called for one hour
*BUG* no its for ne day    



Auth, Rate Limiting, Data Store, Caching  

Sample call from f.ex. PostMan  
POST  https://localhost:7216/tax  
{  
    "VehicleType": "Car",  
    "TimeStamps":[  
       "2013-02-08T06:20:27", "2013-02-08T14:35:00"  
    ]  
}  
  