import requests

def ObtainAPIResponseDatas():
    api_url = "https://localhost:44374/UniversityData?pageNumber=0&perPage=10" 
    session = requests.Session()
    universityDatas = []
    first_page = session.get(api_url, verify=False).json()
    total_Items = first_page['total']
    total_pages = first_page["total_pages"]
    if total_Items > 10:
        universityDatas.extend(first_page["data"])
        
        for page in range(1, total_pages):
            api_url = f"https://localhost:44374/UniversityData?pageNumber={page}&perPage=10" 
            next_page = session.get(api_url).json()
            universityDatas.extend(next_page["data"])
            
        return universityDatas
    
    else:
        return first_page["data"]
        
def FilterForCountryMatches(universityDatas, country):
    countryMatches = []
    for data in list(universityDatas):
        if(data["location"]["country"].lower() == country.lower()):
            countryMatches.append(data)
            
    return countryMatches    
    
  
def SetScoreAsSortKey(universityData):
    return universityData["score"]

def GetBestUniversityByCountry(countryName):
    
    universityDatas = ObtainAPIResponseDatas()
    datasFilteredByCountry = FilterForCountryMatches(universityDatas, country)
    if len(list(datasFilteredByCountry)) == 0:
        return ""
    
    datasFilteredByCountry.sort(reverse = True, key = SetScoreAsSortKey)
    return datasFilteredByCountry[0]["university"]


country = input("Enter the name of a Country to search for its highest rated university. \n")
print("calculating... \n")
bestUniversity = GetBestUniversityByCountry(country)
print(f"The best university in {country} is: {bestUniversity}")




