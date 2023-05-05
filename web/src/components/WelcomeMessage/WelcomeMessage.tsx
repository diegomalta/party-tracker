import React from "react";

interface WelcomeMessageProps {
    guestName: string
}


const WelcomeMessage = ({ guestName }: WelcomeMessageProps) => {
    return (<div className="text-center py-8">
        <h1>{guestName}, You're invited to x's party! &#127881;</h1>
    </div>)
}

export default WelcomeMessage;