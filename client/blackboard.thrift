namespace py blackboard

service BlackboardService {
    string Put(1: string key, 2: string value)
    string Get(1: string key)
    string Del(1: string key)
}