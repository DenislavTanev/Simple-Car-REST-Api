
export function getAll(make) {
    return fetch(`cars/getbymake?make=${make}`)
        .then((response) => response.json());
}

export function getMakes() {
    return fetch('cars/makes')
        .then((response) => response.json());
}

export function getCarById(id) {
    return fetch(`cars/getbyid?id=${id}`)
        .then(res => res.json());
}

export function deleteCar(id) {
    return fetch(`cars?id=${id}`, {
        method: 'DELETE',
    })
        .then(res => res.ok);
}