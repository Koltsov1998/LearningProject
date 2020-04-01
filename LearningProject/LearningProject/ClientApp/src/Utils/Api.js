export default class Api {
    static async GetAllPublicsAsync() {
        var response = await fetch("api/publics");
        return await response.json()
    }

    static async AddPublicAsync(publicUrl) {
        return await fetch(`api/publics?PublicUrl=${publicUrl}`, {
            method: 'POST'
        });
    }

    static async RemovePublic(publicUrl) {
        return await fetch('api/publics', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
            body: publicUrl
        }
        )
    }

    static async StartPhotosParsing(publicId) {
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: publicId
        }
        return await fetch('api/memes/startparsing', options)
    }

    static async CallForMemes(publicId){
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: publicId
        }
        var response = await fetch('api/memes/callformemes', options)
        return await response.json();

    }

    static async GetProgress(publicId){
        const options = {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        }
        var response = await fetch(`/api/memes/${publicId}/progress`, options)
        return await response.json();
    }
}